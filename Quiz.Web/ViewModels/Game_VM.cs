using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.ViewModels
{
    public class Game_VM
    {
        public Guid GameId { get; set; }
        public Guid QuestionId { get; set; }
        public int questionNr { get; set; }
        public string QuestionDescription { get; set; }
        public byte[] ImageData { get; set; }
        public IDictionary<string, bool> Options { get; set; } = new Dictionary<string, bool>();
        //public Question CurrentQuestion { get; set; }
    }
}
