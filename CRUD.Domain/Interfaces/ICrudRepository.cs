using CRUD.Domain.Entities;

namespace CRUD.Domain.Interfaces
{
    public interface ICrudRepository
    {
        Task<List<Carro>> GetAllAsync();
        Task<Carro?> GetByIdAsync(int id);
        Task AddAsync(Carro carro);
        void Update(Carro carro);
        void Delete(Carro carro);
        Task SaveChangesAsync();
    }
}
