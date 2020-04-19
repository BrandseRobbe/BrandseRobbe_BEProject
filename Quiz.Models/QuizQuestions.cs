using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class QuizQuestions
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }

        public QuizClass QuizClass { get; set; }
        public Question Question { get; set; }
    }
}
