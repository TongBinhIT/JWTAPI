using JWTAPI.Data;
using JWTAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAPI.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IModelAreaRepository _areaRepository;

        public AreasController(IModelAreaRepository repo)
        {
            _areaRepository = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAreas()
        {
            try
            {
                return Ok(await _areaRepository.getAllAreaAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAreaById(int id)
        {
            var area = await _areaRepository.getAreaAsync(id);
            return area == null ? NotFound() : Ok(area);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewArea(Area model)
        {
            try
            {
                var newAreaId = await _areaRepository.AddAreaAsync(model);
                var area = await _areaRepository.getAreaAsync(newAreaId);
                return area == null ? NotFound() : Ok(area);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Area model)
        {
            if (id != model.IdArea)
            {
                return NotFound();
            }
            await _areaRepository.UpdateAreaAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _areaRepository.DeleteAreaAsync(id);
            return Ok();
        }

    }
}
