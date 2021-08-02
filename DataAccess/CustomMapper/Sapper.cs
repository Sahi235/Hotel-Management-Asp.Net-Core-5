using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper.Internal;
using DataAccess.Database;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CustomMapper
{
    public class Sapper
    {
        private readonly DatabaseContext _context;

        public Sapper(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<TOut> GetByIdAndMap<TOut, TIn>(Guid id)
        where TIn : BaseEntity
        where TOut : class, new()
        {
            var entity = Get<TIn>();
            List<PropertyInfo> outClassMembers =
                typeof(TOut).GetProperties()
                .Where(e => (e.IsPublic() || e.CanBeSet()) && e.GetType().IsClass && e.Name.EndsWith("dto")).ToList();
            foreach (var outClassMember in outClassMembers)
            {
                entity.Include(outClassMember.Name.Replace("dto", string.Empty));
            }

            var entityResult = await entity.FirstOrDefaultAsync(e => e.Id == id);
            TOut result = new TOut();
            var enteredType = typeof(TIn).GetProperties().Where(e => e.IsPublic() || e.CanBeSet()).ToList();
            var outedType = typeof(TOut).GetProperties().Where(e => e.CanBeSet() || e.IsPublic()).ToList();
            foreach (var outProperty in outedType)
            {
                foreach (var enteredProperty in enteredType.Where(enteredProperty => outProperty.Name.Replace("dto", string.Empty) == enteredProperty.Name))
                {
                    outProperty.SetValue(result, enteredProperty.GetValue(entityResult, null));
                }
            }

            return result;
        }

        //public IQueryable<T> AddInclude<T>(IQueryable<T> query,PropertyInfo info, bool isNested = false)
        //{
        //    if (query == null || info == null)
        //    {
        //        return null;
        //    }

        //    bool isTypeInfoValid = info.GetType().IsClass;
        //    if (!isTypeInfoValid)
        //    {
        //        throw new Exception("Invalid type info");
        //    }

        //    var nestedClasses = info.GetType().GetProperties().Where(e =>
        //        (e.IsPublic() || e.CanBeSet()) && e.GetType().IsClass && e.Name.EndsWith("dto"));
        //    foreach (var VARIABLE in COLLECTION)
        //    {
                
        //    }
        //}

        public IQueryable<T> Get<T>()
        where T : BaseEntity
        {
            var entity = _context.Set<T>().AsQueryable();
            return entity;
        }


    }
}
