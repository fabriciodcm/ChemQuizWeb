using ChemQuizWeb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Models
{
    public class PartyMemberViewModel
    {
        public PartyMemberViewModel(Party party, AppUser member) 
        {
            PartyId = party.PartyId;
            PartyName = party.PartyName;
            PartyDescription = party.PartyDescription;
            Member = member.UserName;
            UserId = member.Id;
        }
        public long PartyId { get; set; }
        [Display(Name = "Party")]
        public string PartyName { get; set; }
        [Display(Name = "Descrição")]
        public string PartyDescription { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Participante")]
        public string Member { get; set; }
    }
}
