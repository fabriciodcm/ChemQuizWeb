using ChemQuizWeb.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Services.Implementations
{
    public class GameService : IGameService
    {
        private ApplicationDbContext Context;

        public GameService(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public Game Create(Game t)
        {
            throw new NotImplementedException();
        }

        public Game Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> FindAll()
        {
            throw new NotImplementedException();
        }

        public Game FindByID(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> FindByParameters(string value, long? categoryid)
        {
            List<Game> games = new List<Game>();
            if (!String.IsNullOrEmpty(value))
            {
                var query = Context.Game
                     .Include(x => x.Author)
                     .Where(x => x.GameName.Contains(value) || x.GameDescription.Contains(value)
                     || x.Author.Email.Contains(value));
                if (categoryid.HasValue)
                    query.Where(x => x.CategoryId == categoryid.Value);
                games = query.Take(10).ToList();
                games.ForEach(x => x.author = x.Author.Email);
            }
            return games;
        }

        public Game Update(Game t)
        {
            throw new NotImplementedException();
        }
    }
}
