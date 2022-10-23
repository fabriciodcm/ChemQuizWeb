using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        bool Exists(long Id);
        IEnumerable<Category> FindAll();
    }
}
