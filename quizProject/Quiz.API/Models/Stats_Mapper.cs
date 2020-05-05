using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Models
{
    public class Stats_Mapper
    {
        public static Stats_DTO ConvertTo_DTO(IEnumerable<Scoreboard_DTO> games, ref Stats_DTO stats_DTO)
        {
            stats_DTO.PlayedGames = games.Count();
            stats_DTO.RightAnswersCount = games.Sum(e => e.correctanswers);
            stats_DTO.RightAnswersCount = games.Sum(e => e.maxquestions) - stats_DTO.RightAnswersCount;

            //foreach(var data in games)
            //{

            //}
            //stats_DTO.Quizgames = games.GroupBy(e=>e.QuizName).Max(e=>)
            return stats_DTO;
        }
    }
}
