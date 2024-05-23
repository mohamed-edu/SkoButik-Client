using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkoButik_Client.Data;
using SkoButik_Client.Models;
using SkoButik_Client.Utility;
using System;

namespace SkoButik_Client.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
    }
}
