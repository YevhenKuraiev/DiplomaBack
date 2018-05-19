using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiplomaBack.DAL.Entities;
using DiplomaBack.DAL.EntityFrameworkCore;
using DiplomaBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaBack.Controllers
{
    [Produces("application/json")]
    [Route("api/Couriers")]
    public class CouriersController : Controller
    {
        private readonly DataBaseContext _appDbContext;
        private readonly UserManager<UserModel> _userManager;
        private readonly IMapper _mapper;

        public CouriersController(UserManager<UserModel> userManager, IMapper mapper, DataBaseContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetCouriers()
        {
            var couriersId = _appDbContext.Couriers;
            var users = _appDbContext.Users;
            var userModels = new List<UserModel>();
            foreach (var courierId in couriersId)
            {
                if (courierId.UserModel == null)
                {
                    userModels.AddRange(users.Where(x => x.Id == courierId.IdentityId));
                }
            }
            return userModels;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> CreateCourierAsync([FromBody]CourierRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<UserModel>(model);
            //userIdentity.UserName = model.FirstName;

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return BadRequest();

            await _appDbContext.Couriers.AddAsync(new CourierModel { IdentityId = userIdentity.Id });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}