using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.ViewModels
{
    public class Scoreboard_VM
    {
        public Guid GameId { get; set; }
        public string QuizId { get; set; }
        public string QuizName { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int correctanswers { get; set; }
        public int maxquestions { get; set; }

        [DisplayFormat(DataFormatString = @"{0:mm\:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan completetime { get; set; }
    }
}
