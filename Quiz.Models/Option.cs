using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quiz.Models
{
    public class Option
    {
        [Key]
        public Guid OptionId { get; set; } = Guid.NewGuid();

        //[Required]
        //[StringLength(50, MinimumLength = 1, ErrorMessage = "The description cannot be longer than 50 characters.")]
        public string OptionDescription { get; set; }

        //[Required]
        public bool CorrectAnswer { get; set; }
        public Guid QuestionId { get; set; }
        public virtual Question CurrentQuestion { get; set; }
    }
}
