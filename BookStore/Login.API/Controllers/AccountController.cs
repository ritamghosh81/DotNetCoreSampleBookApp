using Login.API.Models;
using Login.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.Controllers
{
    [Route("loginapi/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }


        [HttpGet("close")]
        [Authorize]
        public string RestrictedData()
        {
            return "This is a secret";
        }

        [HttpGet("open")]
        [AllowAnonymous]
        public string open()
        {
            return "this is not a secret";
        }


        [HttpGet("sampleuser")]
        [AllowAnonymous]
        public SignUpModel GetSampleUser()
        {
            SignUpModel signUpModel = new SignUpModel
            {
                FirstName = "ritam",
                LastName = "ghosh",
                Email = "ritam@ritam.com",
                Password = "Password@1",
                ConfirmPassword = "Password@1"
            };
            return signUpModel;
        }
    }
}
