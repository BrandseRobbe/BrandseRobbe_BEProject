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
        public string GameId { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string QuizId { get; set; }
        public DateTime TimeStarted { get; set; } = DateTime.Now;
        public DateTime? TimeFinished { get; set; }
        public int CorrectAnswers { get; set; } = 0;
    }
}
