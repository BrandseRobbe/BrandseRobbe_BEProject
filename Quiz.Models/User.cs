using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class User : IdentityUser
    {
        //[Required]
        //[Display(Name = "Name")]
        [MaxLength(25)]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy HH:mm}")] 
        public DateTime? DateOfBirth { get; set; }
        //[Display(Name = "Geslacht")]
        //[EnumDataType(typeof(GenderType), ErrorMessage ="{0} is geen geldige keuze.")]
        //[Range(0,1, ErrorMessage ="Ongeldige keuze")]
        //public GenderType Gender { get; set; }
        //public enum GenderType
        //{
        //    Male = 0,
        //    Female = 1
        //}
        ////[Required]
        //public GenderType Gender { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        //public string ImageUrl
        //{
        //    get
        //    {
        //        return this.Name + ".jpg";
        //    }
        //}

        //public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
