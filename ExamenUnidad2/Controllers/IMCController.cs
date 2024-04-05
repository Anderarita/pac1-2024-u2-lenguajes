using ExamenUnidad2.Dtos;
using ExamenUnidad2.Dtos.IMC;
using ExamenUnidad2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenUnidad2.Controllers
{
    [Route("api/IMC")]
    [ApiController]
    public class IMCController : ControllerBase
    {
        private IIMCServices _imcServices;

        public IMCController(IIMCServices imcServices)
        {
            _imcServices = imcServices;
        }
        [HttpPost]
        public async Task<ActionResult<ResponceDto<IMCDto>>> Create([FromBody] IMCCreateDto model)
        {
            var tasksResponse = await _imcServices.CreateAsync(model);

            return StatusCode(tasksResponse.StatusCode, tasksResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ResponceDto<List<IMCDto>>>> GetAll(string searchTerm = "")
        {
            var TasksResponse = await _imcServices.GetListAsync(searchTerm);

            return StatusCode(TasksResponse.StatusCode, TasksResponse);
        }
    }
}
