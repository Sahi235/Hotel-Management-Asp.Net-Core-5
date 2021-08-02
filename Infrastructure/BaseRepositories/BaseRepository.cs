using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.BaseRepositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
    {
        private readonly DatabaseContext _context;

        protected BaseRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<T> Get(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
