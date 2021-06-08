using Birthday.Entities;
using Birthday.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Birthday.ViewModels
{
    public class DetailsViewModel
    {
        public Voting Voting { get; set; }
        public List<Gift> Gift { get; set; }
        [Display(Name = "Birthday Person")]
        public string CelebratorName { get; set; }
        public List<ResultsViewModel> Results { get; set; }
        public List<ApplicationUser> DidNotVote { get; set; }
        public bool AlreadyVoted { get; set; }
    }
}