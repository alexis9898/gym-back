using BLL.Interface;
using BLL.Models;
using DAL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jym_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleController : ControllerBase
    {
        private readonly IMuscleService _muscleService;

        public MuscleController(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var muscles = await _muscleService.GetAll();
            return Ok(muscles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) 
        {
            var muscle = await _muscleService.Get(id);
            return Ok(muscle);
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] MuscleModel muscleModel)
        {
            var muscle = await _muscleService.Add(muscleModel);
            return Ok(muscle);
        }
        [HttpPut("")]
        public async Task<IActionResult> Set([FromBody] MuscleModel muscleModel)
        {
            var muscle = await _muscleService.Set(muscleModel);
            return Ok(muscle);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var muscle = await _muscleService.Delete(id);
            return Ok(muscle);
        }


    }
}
