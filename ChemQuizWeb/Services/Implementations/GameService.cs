using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Repositories;
using ChemQuizWeb.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Services.Implementations
{
    public class GameService : IGameService
    {
        private IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            this._repository = repository;
        }

        public Game Create(Game game)
        {
            _repository.Add(game);
            return game;
        }

        public void Delete(long Id)
        {
            if (Exists(Id))
                _repository.Remove(_repository.Find(Id));
        }

        public bool Exists(long Id)
        {
            return _repository.List().Any(x => x.GameId == Id);
        }


        public IEnumerable<Game> FindByParameters(string value, long? categoryid)
        {
            List<Game> games = new List<Game>();
            if (!String.IsNullOrEmpty(value))
            {
                var query = _repository.List()
                     .Include(x => x.Author)
                     .Where(x => x.GameName.Contains(value) || x.GameDescription.Contains(value)
                     || x.Author.Email.Contains(value));
                if (categoryid.HasValue)
                    query.Where(x => x.CategoryId == categoryid.Value);
                games = query.Take(10).ToList();
            }
            return games;
        }

        public Task<List<Game>> FindByUser(string UserId)
        {
            return _repository.List()
                .Include(g => g.Author)
                .Include(g => g.Category)
                .Include(g => g.Levels)
                .Where(x => x.AuthorId == UserId).ToListAsync();
        }

        public Task<Game> FindByUser(long GameId, string UserId)
        {
            return _repository.List()
                .Include(g => g.Author)
                .Include(g => g.Category)
                .Include(g => g.Levels)
                .Where(g => g.AuthorId == UserId)
                .FirstOrDefaultAsync(m => m.GameId == GameId);
        }

        public Game Update(Game game)
        {
            if (Exists(game.GameId))
                _repository.Edit(game);
            return game;
        }
    }
}
