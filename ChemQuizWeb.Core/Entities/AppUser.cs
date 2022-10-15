using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChemQuizWeb.Core.Entities
{

    public class AppUser : IdentityUser
    {
        //public long Coins { get; set; }
        [JsonIgnore]
        public ICollection<Game> Games { get; set; }
        [JsonIgnore]
        public ICollection<Party> Parties { get; set; }
    }
}
