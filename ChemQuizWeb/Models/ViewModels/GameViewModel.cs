using ChemQuizWeb.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ChemQuizWeb.Models.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel(Game game) 
        {
            this.GameId = game.GameId;
            this.GameName = game.GameName;
            this.GameDescription = game.GameDescription;
            this.CategoryId = game.CategoryId;
            this.AuthorId = game.AuthorId;
            if (game.Author != null)
                this.Author = game.Author.UserName;
            if (game.Category != null)
                this.Category = game.Category.CategoryName;
            this.Levels = (from level in game.Levels select new LevelViewModel(level)).ToList();
        }

        public long GameId { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string GameName { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string GameDescription { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public long CategoryId { get; set; }
        public string AuthorId { get; set; }
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Display(Name = "Categoria")]
        public string Category { get; set; }
        public List<LevelViewModel> Levels { get; set; }
    }
}
