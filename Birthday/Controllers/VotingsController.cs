using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Birthday.Data;
using Birthday.Entities;
using Microsoft.AspNetCore.Authorization;
using Birthday.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Birthday.Models;
using Birthday.Services;

namespace Birthday.Controllers
{
    [Authorize]
    public class VotingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IVoteService _service;

        public VotingsController(ApplicationDbContext context, IVoteService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Votings
        public async Task<IActionResult> Index()
        {
            var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var votings = await _service.GetAllVotes(currentUserID);

            return View(votings);
        }

        // GET: Votings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var detailsVm = await _service.GetDetails(id.Value);

            if (detailsVm == null)
            {
                return NotFound();
            }

            var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bool alreadyVoted = await _service.CheckVoting((int)id, currentUserID);
            detailsVm.AlreadyVoted = alreadyVoted;

            return View(detailsVm);
        }

        // GET: Votings/Create
        public async Task<IActionResult> Create()
        {
            var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            var vm = await _service.PrepareVote(currentUserID);

            return View(vm);
        }

        // POST: Votings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Voting voting)
        {
            if (ModelState.IsValid)
            {
                bool hasCreatePermission = await _service.PermissionsCheck(voting);
                if (hasCreatePermission)
                {
                    _context.Add(voting);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Show error message
                }

                return RedirectToAction(nameof(Index));
            }
            return View(voting);
        }

        // GET: Votings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var voting = await _context.Votings.FirstOrDefaultAsync(m => m.VotingId == id && m.AdminId == currentUserID);

            if (voting == null)
            {
                return NotFound();
            }

            return View(voting);
        }

        // POST: Votings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Voting voting)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VotingExists(voting.VotingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(voting);
        }


        // GET: Votings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            var voting = await _context.Votings.FirstOrDefaultAsync(m => m.VotingId == id && m.AdminId == currentUserID);

            if (voting == null)
            {
                return View("NoDeletePermission");
            }

            return View(voting);
        }

        // POST: Votings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteVote(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VotingExists(int id)
        {
            return _context.Votings.Any(e => e.VotingId == id);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(SubmitVote submitVote)
        {
            // Get current user
            var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            var success = await _service.Vote(submitVote, currentUserID);

            return RedirectToAction(nameof(Index));
        }
    }
}
