using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz.Models.DTO
{
    public class QuestionMapper
    {
        public static Question_DTO Question_to_DTO(Question_DTO questionDTO, ref Question question)
        {
            questionDTO.Description = question.Description;
            List<Option> options = question.PossibleOptions.ToList<Option>();
            foreach(Option option in options.ToList())
            {
                if(option.CorrectAnswer == true)
                {
                    questionDTO.RightAnswer = option.OptionDescription;
                    options.Remove(option);
                }
            }
            if (options.Count > 0)
            {
                questionDTO.WrongAnswer1 = options[0].OptionDescription;
            }
            if (options.Count > 1)
            {
                questionDTO.WrongAnswer2 = options[1].OptionDescription;
            }
            if (options.Count > 2)
            {
                questionDTO.WrongAnswer3 = options[2].OptionDescription;
            }
            return questionDTO;
        }
    }
}
