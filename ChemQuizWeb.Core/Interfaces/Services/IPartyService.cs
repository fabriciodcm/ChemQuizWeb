using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemQuizWeb.Core.Interfaces.Services
{
    public interface IPartyService
    {
        Task<List<Party>> GetParties();
    }
}
