using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class Person : IdentityUser
    {
        //[Required]
        //[Display(Name = "Name")]
        public string Name { get; set; }
        //[Display(Name = "Geslacht")]
        //[EnumDataType(typeof(GenderType), ErrorMessage ="{0} is geen geldige keuze.")]
        //[Range(0,1, ErrorMessage ="Ongeldige keuze")]
        //public GenderType Gender { get; set; }
        public enum GenderType
        {
            Male = 0,
            Female = 1
        }
        //[Required]
        public GenderType Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ImageUrl
        {
            get
            {
                return this.Name + ".jpg";
            }
        }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
    }
}
