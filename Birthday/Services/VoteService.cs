using Birthday.Data;
using Birthday.Entities;
using Birthday.Models;
using Birthday.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Birthday.Services
{
    public class VoteService : IVoteService
    {
        ApplicationDbContext _context;

        public VoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckVoting(int voteId, string currentUserID)
        {
            return await _context.VotingDetails.Where(x => x.ApplicationUserId == currentUserID && x.VotingId == voteId).Select(x => x.AlreadyVoted).FirstOrDefaultAsync();

        }

        public async Task<bool> Vote(SubmitVote submitVote, string currentUserID)
        {
            var success = false;
            // Check if user is voted
            var alreadyVoted = await _context.VotingDetails.Where(x => x.ApplicationUserId == currentUserID && x.VotingId == submitVote.VoteId).Select(x => x.AlreadyVoted).FirstOrDefaultAsync();
            if (alreadyVoted)
            {
                return success;
            }
            // Record vote in DB
            VotingDetails votingDetails = new VotingDetails()
            {
                VotingId = submitVote.VoteId,
                ApplicationUserId = currentUserID,
                GiftId = submitVote.GiftId,
                AlreadyVoted = true
            };

            _context.Add(votingDetails);
            await _context.SaveChangesAsync();

            success = true;
            return success;
        }

        public async Task<CreateVotingViewModel> PrepareVote(string currentUserID)
        {
            var adminName = await _context.Users.Where(x => x.Id == currentUserID).Select(x => x.FullName).FirstOrDefaultAsync();
            List<ApplicationUser> allUsers = await _context.Users.Where(u => u.Id != currentUserID).AsNoTracking().ToListAsync();
            allUsers.ForEach(u => u.FullName = u.FullName + " - " + u.BirthDate.ToString("dd MMMM yyyy"));

            CreateVotingViewModel createVotingViewModel = new CreateVotingViewModel()
            {
                AdminId = currentUserID,
                AdminName = adminName,
                EmployeeList = allUsers
            };

            return createVotingViewModel;
        }

        public async Task<bool> PermissionsCheck(Voting voting)
        {
            var currentYear = DateTime.Now.Year;
            var previousVotings = await _context.Votings.Where(x => x.CelebratorId == voting.CelebratorId).FirstOrDefaultAsync();
            if (previousVotings == null || previousVotings.VotingStatus != true || voting.Year != currentYear)
            {
                return true;
            }
            return false;
        }

        public async Task<List<VotingViewModel>> GetAllVotes(string currentUserID)
        {
            List<Voting> votingsResult = await _context.Votings.ToListAsync();
            List<VotingViewModel> votings = new List<VotingViewModel>();
            foreach (Voting item in votingsResult)
            {
                if (item.CelebratorId != currentUserID)
                {
                    var admin = await _context.Users.FirstOrDefaultAsync(x => x.Id == item.AdminId);
                    var celebrator = await _context.Users.FirstOrDefaultAsync(x => x.Id == item.CelebratorId);
                    votings.Add(new VotingViewModel()
                    {
                        VotingId = item.VotingId,
                        AdminName = admin?.FullName,
                        CelebratorName = celebrator?.FullName,
                        Birthday = $"{celebrator?.BirthDate.ToString("dd MMMM")} {item.Year}",
                        AdminId = item.AdminId,
                        CelebratorId = item.CelebratorId,
                        VotingStatus = item.VotingStatus,
                        Name = item.Name
                    });
                }
            }
            return votings;
        }

        public async Task<DetailsViewModel> GetDetails(int id)
        {
            var voting = await _context.Votings
                .FirstOrDefaultAsync(m => m.VotingId == id);

            var giftsAvailable = await _context.Gifts.ToListAsync();
            DetailsViewModel detailsVm = new DetailsViewModel();
            detailsVm.Voting = voting;
            detailsVm.Gift = giftsAvailable;

            // Get Celebrator Name
            var celebratorId = voting.CelebratorId;
            detailsVm.CelebratorName = _context.Users.FirstOrDefault(x => x.Id == celebratorId)?.FullName;

            // Get Voted users
            var votesQuery = _context.VotingDetails
                .Where(p => p.VotingId == id)
                .Include(p => p.User)
                .Include(p => p.Gift)
                .ToList();

            var votes = votesQuery.Select(p =>
               new ResultsViewModel()
               {
                   GiftName = p.Gift.GiftName,
                   EmployeeName = p.User.FullName
               }
               ).ToList();

            if (voting == null)
            {
                return null;
            }

            // Get users which don't vote
            var allEmployees = _context.Users.ToList();
            List<ApplicationUser> didNotVote = new List<ApplicationUser>();
            allEmployees.ForEach(x =>
            {
                var voted = _context.VotingDetails.Where(v => v.ApplicationUserId == x.Id).FirstOrDefault();
                if (voted == null && x.Id != celebratorId)
                {
                    didNotVote.Add(x);
                }
            });

            detailsVm.Results = votes;
            detailsVm.DidNotVote = didNotVote;

            return detailsVm;
        }

        public async Task<bool> DeleteVote(int id)
        {
            var voting = await _context.Votings.FindAsync(id);
            _context.Votings.Remove(voting);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
