using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class Role: IdentityRole<string>
    {
        public Role() : base() { }
        public Role(string name) : base(name) { } //nodig in Seeder 
        public string Description { get; set; }
        public Guid QuizId { get; set; } 

        //navigatie properties 
        public virtual QuizClass QuizClass { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public override string Id { get; set; } = Guid.NewGuid().ToString();
        //public string Description { get; set; }
        //public Guid QuizId { get; set; }
    }
}
