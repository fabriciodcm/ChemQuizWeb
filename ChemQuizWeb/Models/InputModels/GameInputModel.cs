using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ChemQuizWeb.Models.InputModels
{
    public class GameInputModel
    {
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

        public Game FromInputModel(Game game)
        {
            game.GameId = this.GameId;
            game.GameName = this.GameName;
            game.CategoryId = this.CategoryId;
            game.GameDescription = this.GameDescription;
            game.AuthorId = this.AuthorId;
            return game;
        }

        public Game FromInputModel()
        {
            var game = new Game();
            game.GameId = this.GameId;
            game.GameName = this.GameName;
            game.CategoryId = this.CategoryId;
            game.GameDescription = this.GameDescription;
            game.AuthorId = this.AuthorId;
            return game;
        }

        public GameViewModel ToViewModel()
        {
            var game = new GameViewModel(FromInputModel());
            return game;
        }
    }
}
