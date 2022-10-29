using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemQuizWeb.UnitTests.Fixtures
{
    public static class PartyFixtures
    {
        public static List<Party> GetTestParties() => new() {
            new (){
                PartyId = 1,
                PartyDescription = "TDD - Introdução",
                PartyName = "Curso de TDD"
            },
            new (){
                PartyId = 2,
                PartyDescription = "Microserviços",
                PartyName = "Curso de Microserviços"
            },
        };
    }
}
