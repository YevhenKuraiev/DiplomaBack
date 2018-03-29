using System.Threading.Tasks;
using DiplomaBack.DAL.Entities;
using DiplomaBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaBack.Controllers.AuthorizationControllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    Name = userModel.Name,
                    Login = userModel.Login
                };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }

            }
            return Ok(userModel);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
                return result.Succeeded ? Ok() : StatusCode(400);
            }
            return StatusCode(400);
        }

        [HttpGet]
        [Route("LogOff")]
        public async Task<IActionResult> LogOff()
        {
            try
            {
                // удаляем аутентификационные куки
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}