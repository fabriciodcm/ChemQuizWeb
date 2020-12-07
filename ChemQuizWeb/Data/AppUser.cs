using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Data
{

    public class AppUser : IdentityUser
    {
        public long Coins { get; set; }
    }
}
