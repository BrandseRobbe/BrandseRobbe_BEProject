using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quiz.Models
{
    public class QuizClass
    {
        [Key]
        public Guid QuizId { get; set; } = Guid.NewGuid();

        [Range(0, 10, ErrorMessage = "Value must be between {1} and {2}.")]
        public int Difficulty { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public ICollection<Game> QuizGames { get; set; } = new List<Game>();
    }
}
