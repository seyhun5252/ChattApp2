using Business.Abstarct;
using Common.DTOs;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ComplainController : Controller
    {
        private IComplainService _complainService;

        public ComplainController(IComplainService complainService)
        {
            _complainService = complainService;
        }

        [HttpGet("GetById")]
        public IActionResult getById(int complainId)
        {
            var getById = _complainService.GetById(complainId);
            if (getById.Errors == null)
            {
                return Ok(getById.value);
            }
            return BadRequest(getById.Errors);
        }
        [HttpPost("Add")]
        public IActionResult Add(ComplainDto complaindto)
        {
            var add = _complainService.Add(complaindto);
            if (add.Errors == null)
            {
                return Ok(add.value);
            }
            return BadRequest(add.Errors);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int complainId)
        {

            var delete = _complainService.Delete(complainId);
            if (delete.Errors == null)
            {
                return Ok(delete.value);
            }
            return BadRequest(delete.Errors);
        }
        [HttpPut("Update")]
        public IActionResult Update(ComplainDto complainDto)
        {
            var update = _complainService.Update(complainDto);
            if (update.Errors == null)
            {
                return Ok(update.value);
            }
            return BadRequest(update.Errors);
        }
        [HttpGet("GetListAll")]
        public IActionResult GetListAll(Complain? complain)
        {
            var getAll = _complainService.GetAll(x => x.ComplainDate ==
            complain!.ComplainDate);
            if (getAll.Errors == null)
            {
                return Ok(getAll.value);
            }
            return BadRequest(getAll!.Errors);
        }
        [HttpGet("GetComplainByUserID")]
        public IActionResult GetComplainByUserID(int userId)
        {
            var getComplainByUserID = _complainService.GetComplainByUserId(userId);
            if (getComplainByUserID.Errors == null)
            {
                return Ok(getComplainByUserID.value);
            }
            return BadRequest(getComplainByUserID!.Errors);
        }

    }
}
