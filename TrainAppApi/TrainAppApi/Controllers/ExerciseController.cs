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
    public class ExerciseController : Controller
    {
        private ApplicationContext _context;
        private SignInManager<UserEntity> _signInManager;
        private UserManager<UserEntity> _userManager;
        public ExerciseController(ApplicationContext context, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        // GET: /<controller>/
        public async Task<IEnumerable<Exercise>> Exercises()
        {
            var user = await _userManager.GetUserAsync(User);
            var userExercises = _context.Exercises.Where(x => x.User.Id == user.Id).OrderByDescending((e) => e.CreationTime);
            return userExercises;
        }
        [HttpPost]
        public async Task<IActionResult> Exercises([FromBody] AddExerciseModel exercise)
        {
            var user = await _userManager.GetUserAsync(User);
            _context.Exercises.Add(new Exercise() { User = user, Name = exercise.Name, RepetitionsCount = exercise.RepetitionsCount, Weight = exercise.Weight, CreationTime = exercise.CreationTime });
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Exercises([FromBody] EditExerciseModel exercise)
        {
            var found = _context.Exercises.SingleOrDefault(x => x.ExerciseId == exercise.ExerciseId);
            found.Name = exercise.Name;
            found.RepetitionsCount = exercise.RepetitionsCount;
            found.Weight = exercise.Weight;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Exercises(Guid id)
        {
            var found = _context.Exercises.SingleOrDefault(x => x.ExerciseId == id);
            _context.Remove(found);
            _context.SaveChanges();
            return Ok();
        }
    }
}
