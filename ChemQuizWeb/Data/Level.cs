using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Data
{
    [Table("Level")]
    public class Level
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LevelId { get; set; }
        [Display(Name = "Fase")]
        public Int16 LevelNumber { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo necessário.")]
        public string LevelDescription { get; set; }
        [Display(Name = "Lição")]
        public string LevelLesson { get; set; }
        public long GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public ICollection<Quiz> Quizes { get; set; }
        [Display(Name = "Level")]
        [NotMapped]
        public string LevelResume
        {
            get
            {
                return " Fase " + LevelNumber + " - " + LevelDescription;
            }
        }
    }
}
