using Birthday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Birthday.Entities
{
    public class VotingDetails
    {
        public int VotingDetailsId { get; set; }
        public int VotingId { get; set; }
        public string ApplicationUserId { get; set; }
        public int GiftId { get; set; }
        public bool AlreadyVoted { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Gift Gift { get; set; }

    }
}
