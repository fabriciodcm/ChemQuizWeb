using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Repositories;
using ChemQuizWeb.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemQuizWeb.Infrastructure.Persistence.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
