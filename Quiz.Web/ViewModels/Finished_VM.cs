using Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.ViewModels
{
    public class Finished_VM
    {
        public string QuizName { get; set; }
        public string QuizDescription { get; set; }
        public int userscore { get; set; }
        public int maxscore { get; set; }
        [DisplayFormat(DataFormatString = @"{0:mm\:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan completetime { get; set; }

        public IEnumerable<IEnumerable<Question>> gameresults { get; set; }
    }
}
