using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using Quiz.Models.DTO;

namespace Quiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> signInMgr;

        public AuthController(SignInManager<User> signInMgr)
        {
            this.signInMgr = signInMgr;
        }

        [HttpPost]
        [Route("login")] //vult de controller basis route aan 
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Login_DTO loginDTO)
        {
            //LoginViewModel met (Required) UserName en Password aanbrengen. 
            var returnMessage = "";
            if (!ModelState.IsValid) return BadRequest("Onvolledige gegevens.");
            try
            {
                //geen persistence, geen lockout -> via false, false 
                var result = await signInMgr.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok("Welkom " + loginDTO.UserName);
                }
                throw new Exception("User of paswoord niet gevonden.");
                //zo algemeen mogelijk response. Vertelt niet dat het pwd niet juist is. 
            }
            catch (Exception exc)
            {
                returnMessage = $"Foutief of ongeldig request: {exc.Message}";
                ModelState.AddModelError("", returnMessage);
            }
            return BadRequest(returnMessage);
            //zo weinig mogelijk (hacker) info 
        }
    }
}
