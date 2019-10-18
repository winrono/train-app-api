using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutAppApi.Entities;

namespace WorkoutAppApi.Controllers
{
    [Route("workout")]
    public class WorkoutController : Controller
    {
        private ApplicationContext _context;
        private SignInManager<UserEntity> _signInManager;
        public WorkoutController(ApplicationContext context, SignInManager<UserEntity> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
        // GET: /<controller>/
        public async Task<string> Index()
        {
            var result = await _signInManager.PasswordSignInAsync("romanmail.by@gmail.com", "Workout1!", true, false);
            if (result.Succeeded)
            {
                return "HEEEEEEEEEEY!";
            }
            return "shit...";
        }
    }
}
