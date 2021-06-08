using Birthday.ViewModels;
using Birthday.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birthday.Services
{
    public interface IVoteService
    {
        public Task<bool> Vote(SubmitVote submitVote, string currentUserID);
        public Task<bool> CheckVoting(int voteId, string currentUserID);
        public Task<CreateVotingViewModel> PrepareVote(string currentUserID);
        public Task<bool> PermissionsCheck(Voting voting);
        public Task<List<VotingViewModel>> GetAllVotes(string currentUserID);
        public Task<DetailsViewModel> GetDetails(int id);
        public Task<bool> DeleteVote(int id);
    }
}
