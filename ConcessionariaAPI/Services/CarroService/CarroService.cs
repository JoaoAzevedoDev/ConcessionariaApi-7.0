using ConcessionariaAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcessionariaAPI.Services.CarroService
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;
        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }
        public Task<ActionResult<List<Carro>>> AddCarro(Carro carro)
        {
            return _carroRepository.AddCarro(carro);
        }

        public Task<ActionResult<List<Carro>>> DeleteCarro(string id)
        {
            return _carroRepository.DeleteCarro(id);
        }

        public Task<ActionResult<List<Carro>>> GetAllCarros()
        {
            var carros = _carroRepository.GetAllCarros();
            return carros;
        }

        public Task<ActionResult<Carro>> GetCarroById(string id)
        {
            return _carroRepository.GetCarroById(id);
        }

        public Task<ActionResult<List<Carro>>> UpdateCarro(Carro request)
        {
            return _carroRepository.UpdateCarro(request);
        }
    }
}
