using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Common.Models.Domain;
using Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Services;

namespace Web_Application.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "Get User By Id")]
        public ActionResult<User> GetById(Guid id)
        {
            return this.ToActionResult(_userService.GetUserById(id));   
        }

        [HttpGet(Name = "Get Users")]
        public ActionResult<IEnumerable<User>> GetAll()
        {

            return this.ToActionResult(_userService.GetUsers());
        }

        [HttpGet(Name = "Get Users Paginated")]
        public ActionResult<Common.Models.Pagination.PagedResult<User>> GetUsersPaginated(int page = 1, int pageSize = 10)
        {
            return this.ToActionResult(_userService.GetUsersPaginated(page, pageSize));
        }

        [HttpPost(Name = "Create User")]
        public ActionResult<User> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            return this.ToActionResult(_userService.CreateUser(createUserDto));
        }
    }
}
