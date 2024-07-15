using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.User;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;

namespace api.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signupManager;
        private readonly ITokenService _tokenService;
        public UserController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signupManager)
        {
            _userManager = userManager;
            _signupManager = signupManager;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };
                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User created");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userManager.Users.FirstOrDefaultAsync(e => e.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid Username!");

            var result = await _signupManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username and Password does not match!");

            return Ok(
                new authUserDto
                {
                    Username = loginDto.Username,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }
    }
}