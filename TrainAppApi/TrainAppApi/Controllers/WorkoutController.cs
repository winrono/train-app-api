using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutAppApi.Entities;

namespace WorkoutAppApi.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private ApplicationContext _context;
        private SignInManager<UserEntity> _signInManager;
        private UserManager<UserEntity> _userManager;
        public WorkoutController(ApplicationContext context, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        // GET: /<controller>/
        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            var user = await _userManager.GetUserAsync(User);
            var userExercises = _context.Exercises.Where(x => x.User.Id == user.Id);
            return userExercises;
        }
        [HttpPost]
        public async Task<IActionResult> AddExercise([FromBody] AddExerciseModel exercise)
        {
            var user = await _userManager.GetUserAsync(User);
            _context.Exercises.Add(new Exercise() { User = user, Name = exercise.Name, RepetitionsCount = exercise.RepetitionsCount, Weight = exercise.Weight });
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditExercise([FromBody] EditExerciseModel exercise)
        {
            var user = await _userManager.GetUserAsync(User);
            var found = _context.Exercises.SingleOrDefault(x => x.ExerciseId == exercise.ExerciseId);
            found.Name = exercise.Name;
            found.RepetitionsCount = exercise.RepetitionsCount;
            found.Weight = exercise.Weight;
            _context.SaveChanges();
            return Ok();
        }
    }
}
