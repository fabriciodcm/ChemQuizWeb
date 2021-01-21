using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Data
{
    [Table("Party")]
    public class Party
    {

        public Party()
        {
            Games = new Collection<Game>();
            Users = new Collection<AppUser>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PartyId { get; set; }
        [Display(Name = "Nome")]
        public string PartyName { get; set; }
        [Display(Name = "Descrição")]
        public string PartyDescription { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
