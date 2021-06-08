using System.ComponentModel.DataAnnotations;

namespace Birthday.ViewModels
{
    public class VotingViewModel
    {
        public int VotingId { get; set; }
        [Display(Name = "Оccasion to celebrate")]
        public string Name { get; set; }
        [Display(Name = "Creator")]
        public string AdminName { get; set; }
        [Display(Name = "Birthday Person")]
        public string CelebratorName { get; set; }
        [Display(Name = "Active")]
        public bool VotingStatus { get; set; }
        public string AdminId { get; set; }
        public string CelebratorId { get; set; }
        public string Birthday { get; set; }

    }
}
