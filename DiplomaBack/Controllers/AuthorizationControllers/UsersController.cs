using System.Threading.Tasks;
using DiplomaBack.DAL.Entities;
using DiplomaBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaBack.Controllers.AuthorizationControllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly UserManager<UserModel> _userManager;

        public UsersController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]UserViewModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400);
            var user = new UserModel { Name = model.Name, UserName = model.Login };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result.Succeeded ? Ok() : StatusCode(400);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] UserModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400);
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return StatusCode(400);
            user.Login = model.Login;
            user.Password = model.Password;
            user.Name = model.Name;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? Ok() : StatusCode(400);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromBody] string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return StatusCode(404);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded ? Ok() : StatusCode(400);
        }
    }
}