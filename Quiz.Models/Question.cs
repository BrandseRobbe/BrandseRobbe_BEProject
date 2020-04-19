﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quiz.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; } = Guid.NewGuid();

        //[Required]
        //[StringLength(450, MinimumLength = 1, ErrorMessage = "The description cannot be longer than 450 characters.")]
        public string Description { get; set; }

        //[StringLength(50, ErrorMessage = "The description cannot be longer than 50 characters.")]

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public virtual ICollection<Option> PossibleOptions { get; set; }
    }
}
