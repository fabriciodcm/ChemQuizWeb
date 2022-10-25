using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChemQuizWeb.Core.Entities
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public long GameId { get; set; }
        [Display(Name = "Nome")]
        public string GameName { get; set; }
        [Display(Name = "Descrição")]
        public string GameDescription { get; set; }
        [Display(Name = "Categoria")]
        public long CategoryId { get; set; }
        [Display(Name = "Autor")]
        public string AuthorId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Categoria")]
        public Category Category { get; set; }
        [ForeignKey("AuthorId")]
        [Display(Name = "Autor")]
        [JsonIgnore]
        public AppUser Author { get; set; }
        public ICollection<Party> Parties { get; set; } 
        public ICollection<Level> Levels { get; set; } 
    }
}
