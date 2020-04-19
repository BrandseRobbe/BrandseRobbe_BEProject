using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.ViewModels
{
    public class RolesForUser_VM
    {
        [BindProperty]
        [Required]
        public Person User { get; set; } //De ApplicationUser 
        //public string UserId { get; set; }
        //public string RoleId { get; set; }
        [BindProperty]
        [Required]
        public string SelectedRoleId { get; set; }
        public IList<string> AssignedRoles { get; set; }
        public IList<string> UnAssignedRoles { get; set; }
    }
}
