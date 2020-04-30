using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.ViewModels
{
    public class Question_VM
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }
        public string Description { get; set; }
        public List<string> OptionDescriptions { get; set; } = new List<string>();
        public List<bool> OptionAnswers { get; set; } = new List<bool>();
        [Display(Name = "Image: ")]
        public IFormFile ImageString { get; set; }
        public byte[] ImageData { get; set; }
    }
}
