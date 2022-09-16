using Business.Abstarct;
using Common.DTOs;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Add(UserDto userDto)
        {
            var result = _userService.Add(userDto);

            if (result.Errors == null)
            {
                return Ok(result);
            }

            return BadRequest(result.Errors);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int userId)
        {

            var result = _userService.Delete(userId);

            if (result.Errors == null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPut("Update")]
        public IActionResult Update(UserDto userDto)
        {
            var update = _userService.Update(userDto);

            if (update.Errors == null)
            {
                return Ok(update.value);
            }

            return BadRequest(update.Errors);
        }
        [HttpGet]
        [Route("[action]/{username}")]
        public IActionResult GetByUserName(string username)
        {
            var getByUserName = _userService.GetByUsername(username);

            if (getByUserName.Errors == null)
            {
                return Ok(getByUserName.value);
            }

            return BadRequest(getByUserName.Errors);
        }
        [HttpGet]
        [Route("[action]/{Id}")]
        public IActionResult getByUserId(int Id)
        {
            var getByUserId = _userService.GetByID(Id);

            if (getByUserId.Errors == null)
            {
                return Ok(getByUserId.value);
            }

            return BadRequest(getByUserId.Errors);
        }
        [HttpGet]
        [Route("[action]/{isActive}")]

        public IActionResult getByUses(bool isActive)
        {
            var getUser = _userService.GetUsers(isActive);

            if (getUser.Errors == null)
            {
                return Ok((getUser.value as List<User>)
                    .Select(x=> new UserDto()
                    {
                        Username = x.Username,
                        UserId = x.UserId,
                        IsActive = x.IsActive,
                        Email = x.Email,
                        CreateDate = x.CreateDate,
                        IsAdmin = x.IsAdmin,
                        Name = x.Name,
                        Password = x.Password,
                        Surname = x.Surname,
                        ProfilePhoto = x.ProfilePhoto,
                    }));
            }

            return BadRequest(getUser.Errors);
        }
    }

}
