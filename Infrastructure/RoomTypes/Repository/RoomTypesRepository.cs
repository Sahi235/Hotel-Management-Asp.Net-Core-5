using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Infrastructure.BaseRepositories;
using Infrastructure.Database;

namespace Infrastructure.RoomTypes.Repository
{
    public class RoomTypesRepository : BaseRepository<RoomType>, IRoomTypesRepository
    {
        private readonly DatabaseContext _context;

        public RoomTypesRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
