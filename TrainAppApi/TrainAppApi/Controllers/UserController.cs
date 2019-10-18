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
        public UserController(SignInManager<UserEntity> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] Credentials credentials)
        {
            await _signInManager.PasswordSignInAsync(credentials.Name, credentials.Password, true, false);
            return Ok();
        }
    }
}