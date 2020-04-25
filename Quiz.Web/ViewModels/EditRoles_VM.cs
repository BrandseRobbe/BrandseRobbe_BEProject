using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.ViewModels
{
    public class EditRoles_VM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IDictionary<string, bool> Roles { get; set; } = new Dictionary<string, bool>();
    }
}
