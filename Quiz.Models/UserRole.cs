using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class UserRole : IdentityUserRole<string>
    {
        public DateTime DateOfentry { get; set; } = DateTime.Now;
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
