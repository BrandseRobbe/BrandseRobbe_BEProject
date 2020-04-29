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
        //[Display(Name = "Id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid QuizId { get; set; }  = Guid.NewGuid();
        public int Difficulty { get; set; }
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }

        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
