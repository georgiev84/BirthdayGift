using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Birthday.Entities
{
    public class Voting
    {
        public int VotingId { get; set; }

        [Display(Name = "Оccasion to celebrate")]
        public string Name { get; set; }
        public string AdminId { get; set; }
        public string CelebratorId { get; set; }
        [Display(Name = "Active")]
        public bool VotingStatus { get; set; }
        public int Year { get; set; }


        public ICollection<VotingDetails> VotingDetails { get; set; }
    }
}
