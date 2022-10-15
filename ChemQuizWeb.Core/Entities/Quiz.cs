using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Core.Entities
{
    [Table("Quiz")]
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long QuizId { get; set; }
        [Required]
        [Display(Name = "Pergunta")]
        public string Question { get; set; }
        [Required]
        [Display(Name = "Resposta 1")]
        public string Answer1 { get; set; }
        [Required]
        [Display(Name = "Resposta 2")]
        public string Answer2 { get; set; }
        [Required]
        [Display(Name = "Resposta 3")]
        public string Answer3 { get; set; }
        [Required]
        [Display(Name = "Resposta 4")]
        public string Answer4 { get; set; }
        [Required]
        [Range(1,4, ErrorMessage = "Número entre 1 e 4.")]
        [Display(Name = "Número Resposta Correta")]
        public short CorrectAnswer { get; set; }
        [Required]
        [Display(Name = "Pontos")]
        public short Points { get; set; }
        public long LevelId { get; set; }
        [ForeignKey("LevelId")]
        public Level Level { get; set; }
    }
}
