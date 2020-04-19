using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quiz.Models.DTO
{
    public class Question_DTO
    {
        public string QuizId { get; set; }
        public string QuestionId { get; set; }
        [Required]
        [DisplayFormat(NullDisplayText = "Needs a input")]
        public string Description { get; set; }
        [Required]
        [DisplayFormat(NullDisplayText = "Needs a input")]
        public string RightAnswer { get; set; }
        [UIHint("Optional")]
        public string WrongAnswer1 { get; set; }
        [UIHint("Optional")]
        public string WrongAnswer2 { get; set; }
        [UIHint("Optional")]
        public string WrongAnswer3 { get; set; }
    }
}
