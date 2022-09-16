using Business.Abstarct;
using Common.DTOs;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FriendController : Controller
    {
        private IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("GetList")]
        public IActionResult GetList(int friendId)
        {
            var getListFriend = _friendService.GetList(friendId);
            if (getListFriend.Errors == null)
            {
                return Ok(getListFriend.value);
            }
            return BadRequest(getListFriend.Errors);
        }
        [HttpPost("Add")]
        public IActionResult Add(FriendDto friendDto)
        {
            var addFriend = _friendService.Add(friendDto);
            if (addFriend.Errors == null)
            {
                return Ok(addFriend.value);
            }
            return BadRequest(addFriend.Errors);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int friendId)
        {
            var delete = _friendService.Delete(friendId);
            if (delete.Errors == null)
            {
                return Ok(delete.value);
            }
            return BadRequest(delete.Errors);
        }
        [HttpPut("Update")]
        public IActionResult Update(FriendDto friendDto)
        {
            var update = _friendService.Update(friendDto);
            if (update.Errors == null)
            {
                return Ok(update.value);
            }
            return BadRequest(update.Errors);
        }
    }
}
