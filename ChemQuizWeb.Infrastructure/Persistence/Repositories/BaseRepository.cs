using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Repositories;
using ChemQuizWeb.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemQuizWeb.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public T Find(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Remove(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void Edit(T item)
        {
            _context.Attach<T>(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
