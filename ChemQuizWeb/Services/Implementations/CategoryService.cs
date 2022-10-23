using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Services;
using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemQuizWeb.Infrastructure.Persistence.Repositories;
using ChemQuizWeb.Core.Interfaces.Repositories;

namespace ChemQuizWeb.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public Category Create(Category t)
        {
            throw new NotImplementedException();
        }

        public Category Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long Id)
        {
            return _repository.List().Any(x => x.CategoryId == Id);
        }

        public IEnumerable<Category> FindAll()  => _repository.List().ToList();
       
        public Category FindByID(long Id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category t)
        {
            throw new NotImplementedException();
        }

        void IService<Category>.Delete(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
