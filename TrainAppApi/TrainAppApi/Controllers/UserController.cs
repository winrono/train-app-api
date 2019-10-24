using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutAppApi.Entities;

namespace WorkoutAppApi.Controllers
{
    public class UserController : Controller
    {
        private SignInManager<UserEntity> _signInManager;
        private UserManager<UserEntity> _userManager;
        public UserController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] Credentials credentials)
        {
            await _signInManager.PasswordSignInAsync(credentials.Name, credentials.Password, true, false);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Credentials credentials)
        {
            var user = new UserEntity { UserName = credentials.Name, Email = credentials.Name };
            var result = await _userManager.CreateAsync(user, credentials.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}