using System.ComponentModel.DataAnnotations;
using System;
using ChemQuizWeb.Core.Entities;
using System.Collections.Generic;

namespace ChemQuizWeb.Models.ViewModels
{
    public class LevelViewModel
    {
        public long LevelId { get; set; }
        [Display(Name = "Fase")]
        public Int16 LevelNumber { get; set; }
        [Display(Name = "Descrição")]
        public string LevelDescription { get; set; }
        public long GameId { get; set; }

        public LevelViewModel(Level level)
        {
            this.LevelId = level.LevelId;
            this.LevelNumber = level.LevelNumber;
            this.LevelDescription = level.LevelDescription;
            this.GameId = level.GameId;
        }
    }
}
