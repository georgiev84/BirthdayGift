using Birthday.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Birthday.ViewModels
{
    public class CreateVotingViewModel
    {
        public int VotingId { get; set; }
        [Required]
        [Display(Name = "Оccasion to celebrate")]
        public string Name { get; set; }
        public string AdminId { get; set; }
        public string AdminName { get; set; }
        public string CelebratorName { get; set; }
        [Required]
        [Range(2021, 2100)]
        public int Year { get; set; }
        public List<ApplicationUser> EmployeeList { get; set; }
        public string CelebratorId { get; set; }
        [Display(Name = "Active")]
        public bool VotingStatus { get; set; }
    }
}
