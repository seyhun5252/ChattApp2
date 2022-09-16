using Business.Abstarct;
using Common.DTOs;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ChattApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GroupMemberController : Controller
    {
        private IGroupMemberService _groupMemberService;

        public GroupMemberController(IGroupMemberService groupMemberService)
        {
            _groupMemberService = groupMemberService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int groupId)
        {
            var getAllGroupMember = _groupMemberService.GetAll(groupId);
            if (getAllGroupMember.Errors == null)
            {
                return Ok(getAllGroupMember.value);
            }
            return BadRequest(getAllGroupMember.Errors);
        }
        [HttpPost("Add")]
        public IActionResult Add(GroupMemberDto groupMemberDto)
        {
            var add = _groupMemberService.Add(groupMemberDto);
            if (add.Errors == null)
            {
                return Ok(add.value);
            }
            return BadRequest(add.Errors);
        }
        [HttpPut("Update")]
        public IActionResult Update(GroupMemberDto groupMemberDto)
        {
            var update = _groupMemberService.Update(groupMemberDto);

            if (update.Errors == null)
            {
                return Ok(update.value);
            }
            return BadRequest(update.Errors);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int groupMemberId)
        {
            var delete = _groupMemberService.Delete(groupMemberId);
            if (delete.Errors == null)
            {
                return Ok(delete.value);
            }
            return BadRequest(delete.Errors);
        }

    }
}
