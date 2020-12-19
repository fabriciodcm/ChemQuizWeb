using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Data
{
    public class Party
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PartyId { get; set; }
        public string PartyName { get; set; }
        public string PartyDescription { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
