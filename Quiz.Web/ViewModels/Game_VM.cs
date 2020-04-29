using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.ViewModels
{
    public class Game_VM
    {
        public string GameId { get; set; } = new Guid().ToString();
        public string QuestionId { get; set; }
        public string QuestionDescription { get; set; }
        public byte[] ImageData { get; set; }
        public IDictionary<string, bool> Options { get; set; } = new Dictionary<string, bool>();
        //public Question CurrentQuestion { get; set; }
    }
}
