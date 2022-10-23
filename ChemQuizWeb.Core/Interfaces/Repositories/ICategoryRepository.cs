using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemQuizWeb.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>, IDisposable
    {
    }
}
