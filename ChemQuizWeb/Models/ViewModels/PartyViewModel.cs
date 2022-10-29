using ChemQuizWeb.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChemQuizWeb.Models.ViewModels
{
    public class PartyViewModel
    {
        public long PartyId { get; set; }
        [Display(Name = "Nome")]
        public string PartyName { get; set; }
        [Display(Name = "Descrição")]
        public string PartyDescription { get; set; }

        public static implicit operator PartyViewModel(Party party) 
        {
            return new PartyViewModel()
            {
                PartyDescription = party.PartyDescription,
                PartyId = party.PartyId,
                PartyName = party.PartyName
            };
        }
    }
}
