using Microsoft.AspNetCore.Identity;
using System;

namespace Birthday.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
