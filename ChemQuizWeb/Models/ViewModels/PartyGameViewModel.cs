using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Models.ViewModels
{
    public class PartyGameViewModel
    {
        public PartyGameViewModel(Party party, Game game)
        {
            GameId = game.GameId;
            GameName = game.GameName;
            GameAuthor = game.Author.Email;
            Category = game.Category.CategoryName;
            PartyId = party.PartyId;
            PartyName = party.PartyName;
            PartyDescription = party.PartyDescription;
        }
        public long GameId { get; set; }
        [Display(Name = "Game")]
        public string GameName { get; set; }
        [Display(Name = "Categoria")]
        public string Category { get; set; }
        [Display(Name = "Criador")]
        public string GameAuthor { get; set; }
        public long PartyId { get; set; }
        [Display(Name = "Party")]
        public string PartyName { get; set; }
        [Display(Name = "Descrição")]
        public string PartyDescription { get; set; }

    }
}
