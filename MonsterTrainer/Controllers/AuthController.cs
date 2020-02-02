using Domain.Data;
using Domain.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(Context context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("signin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInDto info)
        {
            var user = await _userManager.FindByNameAsync(info.UserName);

            if (user is null)
            {
                return new UnauthorizedResult();
            }

            bool isOk = await _userManager.CheckPasswordAsync(user, info.Password);

            if (!isOk)
            {
                return new UnauthorizedResult();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, info.UserName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

            return Ok();
        }

        [HttpPost("signup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpDto info)
        {
            if (info is null)
                return BadRequest();
            if (string.IsNullOrWhiteSpace(info.UserName))
                return BadRequest();
            if (string.IsNullOrWhiteSpace(info.Password))
                return BadRequest();

            await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = info.UserName
            }, info.Password);

            return await SignIn(new SignInDto { UserName = info.UserName, Password = info.Password });
        }

        [HttpPost("signout")]
        public async Task<IActionResult> SignOut(SignUpDto info)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
