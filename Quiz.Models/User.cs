using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class User : IdentityUser
    {
        public User() : base() { }
        public User(string name) : base(name) { }
        //[Required]
        //[Display(Name = "Name")]
        [MaxLength(25)]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy HH:mm}")] 
        //public DateTime? DateOfBirth { get; set; }

        //public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
