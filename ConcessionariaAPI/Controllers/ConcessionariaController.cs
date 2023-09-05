using ConcessionariaAPI.Services.CarroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcessionariaController : ControllerBase
    {
        private readonly ICarroService _carroService;
        public ConcessionariaController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Carro>>> GetAllCarros()
        {
            var carros = await _carroService.GetAllCarros();
            return Ok(carros.Value);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarroById(string id)
        {
            var carro = _carroService.GetCarroById(id);
            if (carro == null)
                return BadRequest("Carro not found.");
            return Ok(carro.Result.Value);
        }

        [HttpPost]
        public async Task<ActionResult<List<Carro>>> AddCarro(Carro carro)
        {
            var request = await _carroService.AddCarro(carro);
            return Ok(request.Value);
        }

        [HttpPut]
        public async Task<ActionResult<List<Carro>>> UpdateCarro(Carro request)
        {
            var dbCarro = await _carroService.UpdateCarro(request);
            if (dbCarro == null)
                return BadRequest("Carro not found.");

            return Ok(dbCarro.Value);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carro>> DeleteCarro(string id)
        {
            var request = await _carroService.DeleteCarro(id);
            if (request == null)
                return BadRequest("Carro not found.");
            return Ok(request.Value);
        }
    }
}
