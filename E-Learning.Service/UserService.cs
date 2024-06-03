using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Interfaces.Services;
using E_Learning.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Learning.Service
{
    public class UserService /*: IUserService*/
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly ITokenService _tokenService;

        //public UserService(UserManager<ApplicationUser> userManager,
        //    SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _tokenService = tokenService;
        //}

        //public async Task<UserDTOIdentity?> LoginAsync(LogInDto dto)
        //{
        //    //Email => User Check => Password => Create Token => return dto
        //    var user = await _userManager.FindByEmailAsync(dto.Email);
        //    if (user is not null)
        //    {
        //        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        //        if (result.Succeeded)
        //            return new UserDTOIdentity
        //            {
        //                DisplayName = user.DisplayName,
        //                Email = user.Email,
        //                Token = _tokenService.GenerateToken(user)
        //            };
        //    }
        //    return null;

        //}


        //public async Task<UserDTOIdentity> RegisterAsync(RegisterDto dto)
        //{
        //    var user = await _userManager.FindByEmailAsync(dto.Email);
        //    if (user is not null) throw new Exception("Email Exists");
        //    var appUser = new ApplicationUser
        //    {
        //        DisplayName = dto.DisplayName,
        //        Email = dto.Email,
        //        UserName = dto.DisplayName
        //    };
        //    var result = await _userManager.CreateAsync(appUser, dto.Password);
        //    if (!result.Succeeded) throw new Exception("Error");

        //    return new UserDTOIdentity
        //    {
        //        DisplayName = appUser.DisplayName,
        //        Email = appUser.Email,
        //        Token = _tokenService.GenerateToken(appUser)
        //    };

        //}
    }
}
