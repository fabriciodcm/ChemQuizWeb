using ChemQuizWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Services
{
    public interface IGameService : IService<Game>
    {
        IEnumerable<Game> FindByParameters(string value, long? categoryid);
    }
}
