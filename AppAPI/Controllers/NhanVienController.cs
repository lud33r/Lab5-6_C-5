using AppAPI.IService;
using AppAPI.ViewModels;
using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly IObjectService _objSer;
        public NhanVienController(IObjectService objectService)
        {
            _objSer = objectService;
        }
        // GET: api/<NhanVienController>
        [HttpGet("get-all-item")]
        public async Task<List<NhanVienVM>> GetAll()
        {
            return await _objSer.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NhanVienVM nv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var check = await _objSer.Create(nv);
            if (check == false)
                return BadRequest();

            return Ok();

        }

        // PUT api/<NhanVienController>/5
        [HttpPut("edit-item/{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] NhanVienVM nv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _objSer.Update(nv);
            if (result == false)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _objSer.Delete(id);
            if (result == false)
                return BadRequest();
            return Ok();
        }
        [HttpGet("tinh-can-nang")]
        public float BMI(float weight, float height)
        {
            float bmi;
            return bmi = weight / (height * height);
        }
    }
}
