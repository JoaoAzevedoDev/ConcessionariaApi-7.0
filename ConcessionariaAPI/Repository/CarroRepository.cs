using ConcessionariaAPI.Configuration;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ConcessionariaAPI.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly IMongoCollection<Carro> _carroCollection;
        
        public CarroRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);
            _carroCollection = database.GetCollection<Carro>("carros");
            ;
        }

        public async Task<ActionResult<List<Carro>>> AddCarro(Carro carro)
        {
            await _carroCollection.InsertOneAsync(carro);
            return await _carroCollection.Find(h => true).ToListAsync();
        }

        public async Task<ActionResult<List<Carro>>> DeleteCarro(string id)
        {
            var carro = _carroCollection.Find(h => h.Id == id).FirstOrDefault();
            if (carro == null)
                return null;
            _carroCollection.DeleteOne(h => h.Id == id);
            return await _carroCollection.Find(h => true).ToListAsync();
        }

        public async Task<ActionResult<List<Carro>>> GetAllCarros()
        {
            var carros = await _carroCollection.Find(h => true).ToListAsync();
            return carros;
        }

        public async Task<ActionResult<Carro>> GetCarroById(string id)
        {
            var carro = _carroCollection.Find(h => h.Id == id).FirstOrDefault();
            if (carro == null)
                return null;
            return carro;
        }

        public async Task<ActionResult<List<Carro>>> UpdateCarro(Carro request)
        {
            var dbCarro = _carroCollection.Find(h => h.Id == request.Id).FirstOrDefault();
            if (dbCarro == null)
                return null;

            dbCarro.Nome = request.Nome;
            dbCarro.Marca = request.Marca;
            dbCarro.Categoria = request.Categoria;
            dbCarro.Ano = request.Ano;
            dbCarro.Valor = request.Valor;

            await _carroCollection.ReplaceOneAsync(h => h.Id == dbCarro.Id, dbCarro);
            return await _carroCollection.Find(h => true).ToListAsync();
        }
    }
}
