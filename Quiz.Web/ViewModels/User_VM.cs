using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Web.ViewModels
{
    public class User_VM
    {

        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Roles { get; set; }
        //public DateTime? DateOfBirth { get; set; }
    }
}
