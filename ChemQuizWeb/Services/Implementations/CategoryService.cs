using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Services;
using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Services.Implementations
{
    public class CategoryService : IService<Category>
    {
        private ApplicationDbContext Context;

        public CategoryService(ApplicationDbContext Context)
        {
            this.Context = Context;
        }
        public Category Create(Category t)
        {
            throw new NotImplementedException();
        }

        public Category Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> FindAll()  => Context.Category.ToList();
       
        public Category FindByID(long Id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
