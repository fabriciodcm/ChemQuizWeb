using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemQuizWeb.Infrastructure.Persistence.Repositories;
using ChemQuizWeb.Core.Interfaces.Repositories;

namespace ChemQuizWeb.Services.Implementations
{
    public class PartyService : IPartyService
    {
        //private readonly IPartyRepository _repository;

        public PartyService()
        {

        }

        public Task<List<Party>> GetParties()
        {
            throw new NotImplementedException();
        }
    }
}
