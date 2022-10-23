using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Core.Interfaces.Services
{
    public interface IGameService
    {
        IEnumerable<Game> FindByParameters(string value, long? CategoryId);
        Task<List<Game>> FindByUser(string UserId);
        Task<Game> FindByUser(long GameId, string UserId);
        Game Create(Game game);
        void Delete(long Id);
        bool Exists(long Id);
        Game Update(Game game);
    }
}
