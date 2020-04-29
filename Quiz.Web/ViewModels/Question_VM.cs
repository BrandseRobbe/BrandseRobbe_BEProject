using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.ViewModels
{
    public class Question_VM
    {
        public Guid QuizId { get; set; }
        public string Description { get; set; }
        public List<string> OptionDescriptions { get; set; } = new List<string>();
        public List<bool> OptionAnswers { get; set; } = new List<bool>();
        public IFormFile ImageString { get; set; }
        public int OptionCount { get; set; }
        //public IDictionary<string, bool> Options { get; set; } = new Dictionary<string, bool>();
    }
}
