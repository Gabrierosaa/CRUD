using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;

namespace CRUD.Infrastructure.Repositories
{
    public class InMemoryCrudRepository : ICrudRepository
    {
        private readonly List<Carro> _carros = [];
        private int _nextId = 1;

        public Task<List<Carro>> GetAllAsync()
        {
            return Task.FromResult(_carros.ToList());
        }

        public Task<Carro?> GetByIdAsync(int id)
        {
            var carro = _carros.FirstOrDefault(carro => carro.Id == id);
            return Task.FromResult(carro);
        }

        public Task AddAsync(Carro carro)
        {
            carro.DefinirId(_nextId++);
            _carros.Add(carro);

            return Task.CompletedTask;
        }

        public void Update(Carro carro)
        {
            var index = _carros.FindIndex(item => item.Id == carro.Id);

            if (index >= 0)
                _carros[index] = carro;
        }

        public void Delete(Carro carro)
        {
            _carros.Remove(carro);
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
