using Business.Abstarct;
using Common.DTOs;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("GetPrivateMessage")]
        public IActionResult IndexGetPrivateMessage(int senderId, int receiverId)
        {
            var getPrivateMessage = _messageService.GetPrivateMessage(senderId, receiverId);
            if (getPrivateMessage.Errors == null)
            {
                return Ok(getPrivateMessage.value);
            }
            return BadRequest(getPrivateMessage.Errors);
        }
        [HttpGet("GetGroupMessage")]
        public IActionResult GetGroupMessage(int senderId, int groupId)
        {
            var getGroupMessage = _messageService.GetPrivateMessage(senderId, groupId);
            if (getGroupMessage.Errors == null)
            {
                return Ok(getGroupMessage.value);
            }
            return BadRequest(getGroupMessage.Errors);
        }
        [HttpPost("SendMessage")]
        public IActionResult SendMessage(MessageDto messageDto)
        {
            var sendMessage = _messageService.SendMessage(messageDto);

            if (sendMessage.Errors == null)
            {
                return Ok(sendMessage.value);
            }

            return BadRequest(sendMessage.Errors);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int messageId)
        {
            var delete = _messageService.Delete(messageId);

            if (delete.Errors == null)
            {
                return Ok(delete.value);
            }

            return BadRequest(delete.Errors);
        }
    }
}
