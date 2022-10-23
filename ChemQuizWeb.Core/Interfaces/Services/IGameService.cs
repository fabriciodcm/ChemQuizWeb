using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Core.Interfaces.Services
{
    public interface IGameService : IService<Game>
    {
        IEnumerable<Game> FindByParameters(string value, long? CategoryId);
        public Task<List<Game>> FindByUser(string UserId);
        public Task<Game?> FindByUser(long GameId, string UserId);
    }
}
