using E_Learning.Core.Interfaces.Services;
using E_Learning.Core.Models;
using E_Learning.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration config;

        public TokenService(IConfiguration Config)
        {
            config = Config;
        }
        public async Task<string> CreateTokenAsync(AppUser User, UserManager<AppUser> UManager)
        {
            #region Payload By User Defiend  -- Private Claims
            var AUTHClaims = new List<Claim>()//Private Claims -- UserDefiend
            {
               //new Claim( ClaimTypes.GivenName,User.DisplayName),
               new Claim( ClaimTypes.GivenName,User.UserName),

               new Claim( ClaimTypes.Email,User.Email)
            };
            var Roles = await UManager.GetRolesAsync(User);

            foreach (var Role in Roles)
            {
                AUTHClaims.Add(new Claim(ClaimTypes.Role, Role));
            }
            #endregion





            #region Key
            var AuthKeys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));//Get From AppSetting 
            #endregion


            var token = new JwtSecurityToken(
                issuer: config["Jwt:Isuuer"],
                audience: config["Jwt:audience"],
                expires: DateTime.Now.AddDays(double.Parse(config["Jwt:expires"])),
                claims: AUTHClaims,
                signingCredentials: new SigningCredentials(AuthKeys, SecurityAlgorithms.HmacSha256Signature)
                );

            #region End Return Token
            var Token = new JwtSecurityTokenHandler().WriteToken(token);


            #endregion
            return Token;

       
        }
    }
}