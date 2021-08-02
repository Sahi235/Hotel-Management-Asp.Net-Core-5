using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using DataAccess.Hotels.Command;
using DataAccess.Hotels.Dto;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace DataAccess.Hotels.Handler
{
    public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, GetHotelDto>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _environment;

        public CreateHotelHandler(DatabaseContext context,
                                  IMapper mapper, IHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }
        public async Task<GetHotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var imageUrl = await this.UploadFile(request.CreateHotelDto.File);
            var result = _mapper.Map<Hotel>(request.CreateHotelDto);
            result.MainImageUrl = imageUrl;
            await _context.Hotels.AddAsync(result, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<GetHotelDto>(result);
        }

        public async Task<string> UploadFile(IFormFile file, string fileName = "")
        {
            try
            {
                var photos = _environment.ContentRootPath + "\\Photos\\";
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = Guid.NewGuid().ToString("D");
                }
                await using FileStream fs = System.IO.File.Create(photos + fileName);
                await file.CopyToAsync(fs);
                await fs.FlushAsync();
                return file.Name;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
