using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaAPI.Services.CarroService
{
    public interface ICarroService
    {
        Task<ActionResult<List<Carro>>> GetAllCarros();
        Task<ActionResult<Carro>> GetCarroById(string id);
        Task<ActionResult<List<Carro>>> AddCarro(Carro carro);
        Task<ActionResult<List<Carro>>> UpdateCarro(Carro request);
        Task<ActionResult<List<Carro>>> DeleteCarro(string id);
    }
}
