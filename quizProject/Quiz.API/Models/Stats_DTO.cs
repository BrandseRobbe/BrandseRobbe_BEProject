using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Models
{
    public class Stats_DTO
    {
        public int PlayedGames { get; set; }
        public int RightAnswersCount { get; set; }
        public int WrongAnswersCount { get; set; }

        public IDictionary<string, int> Usergames { get; set; } 
        public IDictionary<string, int> Quizgames { get; set; }

    }
}
