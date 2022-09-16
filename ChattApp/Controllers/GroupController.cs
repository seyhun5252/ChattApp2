using Business.Abstarct;
using Common.DTOs;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("Get")]
        public IActionResult Get(int groupId)
        {
            var getGroup = _groupService.GetList(groupId);
            if (getGroup.Errors == null)
            {
                return Ok(getGroup.value);
            }
            return BadRequest(getGroup.Errors);
        }

        [HttpPost]
        public IActionResult Add(GroupDto groupdDto)
        {
            var add = _groupService.Add(groupdDto);

            if (add.Errors == null)
            {
                return Ok(add.value);
            }

            return BadRequest(add.Errors);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int groupId)
        {
            var delete = _groupService.Delete(groupId);

            if (delete.Errors == null)
            {
                return Ok(delete.value);
            }

            return BadRequest(delete.Errors);
        }
        [HttpPut("Update")]
        public IActionResult Update(GroupDto groupDto)
        {
            var update = _groupService.Update(groupDto);

            if (update.Errors == null)
            {
                return Ok(update.value);
            }

            return BadRequest(update.Errors);
        }
    }
}
