using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Interfaces.Services;
using E_Learning.Core.Models;
using E_Learning.Error;
using E_Learning.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        public AccountsController(SignInManager<AppUser> signInManager, ITokenService tokenService, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTOIdentity>> Login(LogInDto Model)
        {
            



        var User = await _userManager.FindByEmailAsync(Model.Email.Trim().ToLower());
            if (User != null)
            {

                var Sign = await _signInManager.CheckPasswordSignInAsync(User, Model.Password, false);
                if (Sign.Succeeded)
                {
                    var Resulte = new UserDTOIdentity()
                    {
                        DisplayName = User.UserName,
                        Token = await _tokenService.CreateTokenAsync(User, _userManager),
                        Email = User.Email
                    };
                    return Ok(Resulte);
                }
                return Unauthorized(new ApiResponse(401));


            }
            return Unauthorized(new ApiResponse(401));
        }



        //private readonly IUserService _userService;

        //public AccountsController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        //[HttpPost("Login")]
        //public async Task<ActionResult<UserDTOIdentity>> Login(LogInDto input)
        //{
        //    var user = await _userService.LoginAsync(input);
        //    return user is not null ? Ok(user) : Unauthorized(new ApiResponse(401, "Incorrect Email Or Password"));
        //}

        //[HttpPost("Register")]
        //public async Task<ActionResult<UserDTOIdentity>> Register(RegisterDto input)
        //{
        //    return Ok(await _userService.RegisterAsync(input));
        //}
    }
}
