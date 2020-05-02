using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class GameQuestion
    {
        public Guid GameId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid CorrectQuestionId { get; set; }


        public Game Game { get; set; }
        public Question Question { get; set; }
    }
}
