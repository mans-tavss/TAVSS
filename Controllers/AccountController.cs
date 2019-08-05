using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TAVSS.Data;
using TAVSS.Models;

namespace TAVSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // Dependancy Injection
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SRegister([FromBody] StudentModel formdata)
        {
        
            List<string> errorList = new List<string>();
           



            var user = new IdentityUser {
                Email = formdata.Email,
                UserName =formdata.SName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

          
            //var result = await _userManager.CreateAsync(user, formdata.Password);
            //if (result.Succeeded)
            //{
            //    await _userManager.AddToRoleAsync(user, "Student");
            //    _context.Students.Add(formdata);
            //    await _context.SaveChangesAsync();
            //    return Ok(new { username = user.UserName, email = user.Email, status = 1, message = "Registeration Successful" });
            //}
            //else
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError("", error.Description);
            //        errorList.Add(error.Description);
            //    }
            //}

            return BadRequest(new JsonResult(errorList));


        }

    }
}