using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quiz.Models
{
    public class Game
    {
        [Required]
        [Key]
        public Guid GameId { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public Guid QuizId { get; set; }
        public DateTime TimeStarted { get; set; } = DateTime.Now;
        public DateTime? TimeFinished { get; set; }
        public int CorrectAnswers { get; set; } = 0;
    }
}
