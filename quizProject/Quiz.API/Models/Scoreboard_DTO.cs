using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Models
{
    public class Scoreboard_DTO
    {
        public Guid GameId { get; set; }
        public string QuizId { get; set; }
        public string QuizName { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int correctanswers { get; set; }
        public int maxquestions { get; set; }
        public TimeSpan completetime { get; set; }
    }
}
