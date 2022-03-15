using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SMEcommerce.Models.EntityModels.Identity;
using SMEcommerceApp.Models.Auth;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Microsoft.AspNetCore.Authorization;

namespace SMEcommerceApp.Controllers
{
    public class AuthController : Controller
    {
        SignInManager<AppUser> _SignInManager;
        UserManager<AppUser> _UserManager;
        IPasswordHasher<AppUser> _passwordHasher;
        IConfiguration _config;
        public AuthController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,IPasswordHasher<AppUser> passwordHasher,IConfiguration config)
        {
            _SignInManager = signInManager;
            _UserManager = userManager;
            _passwordHasher = passwordHasher;
            _config = config;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        ////   
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _UserManager.FindByNameAsync(model.UserName);

            if(user!=null)
            {
                var result = await _SignInManager.PasswordSignInAsync(model.UserName,model.Password,false,false);

                if(result.Succeeded)
                {
                    //return View("AdminHome", "Home");
                    return RedirectToAction("AdminHome", "Home");
                }
            }
            return View();

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            //code
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = model.Email,
                    Email = model.Email,

                };
            var result = await _UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
              
            }
 

            return View();


        }



        [HttpPost]
        public async Task<IActionResult> Token([FromBody] LoginViewModel model)
        {
            var user = await _UserManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                // verify password 

                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

                if (result == PasswordVerificationResult.Success)
                {
                    // token generate for user. 

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var userClaims = await _UserManager.GetClaimsAsync(user);


                    var claims = new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, (new Guid()).ToString()),
                        new Claim("Permission" , "Admin"),
                        new Claim("Permission" , "BangladeshiUser")

                    }.Union(userClaims);


                    var token = new JwtSecurityToken(
                        issuer: _config["Jwt:Issuer"],
                        audience: _config["Jwt:Issuer"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: signingCredentials
                        );


                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new { token = tokenString, expires = token.ValidTo });

                }


            }



        

            return BadRequest("User or Password could not match, please check");

        }
    }
}
