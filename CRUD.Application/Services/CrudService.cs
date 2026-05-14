using CRUD.Application.DTOs;
using CRUD.Application.Interfaces;
using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;

namespace CRUD.Application.Services
{
    public class CrudService : ICrudService
    {
        private readonly ICrudRepository _repository;

        public CrudService(ICrudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CrudResponseDto>> GetAllAsync()
        {
            var carros = await _repository.GetAllAsync();
            return carros.Select(ToResponseDto).ToList();
        }

        public async Task<CrudResponseDto?> GetByIdAsync(int id)
        {
            var carro = await _repository.GetByIdAsync(id);
            return carro is null ? null : ToResponseDto(carro);
        }

        public async Task<CrudResponseDto> AddAsync(CrudCreateDto dto)
        {
            var carro = new Carro(0, dto.Modelo, dto.Ativo);

            await _repository.AddAsync(carro);
            await _repository.SaveChangesAsync();

            return ToResponseDto(carro);
        }

        public async Task<bool> UpdateAsync(int id, CrudUpdateDto dto)
        {
            var carro = await _repository.GetByIdAsync(id);

            if (carro is null)
                return false;

            carro.Atualizar(dto.Modelo, dto.Ativo);
            _repository.Update(carro);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var carro = await _repository.GetByIdAsync(id);

            if (carro is null)
                return false;

            _repository.Delete(carro);
            await _repository.SaveChangesAsync();

            return true;
        }

        private static CrudResponseDto ToResponseDto(Carro carro)
        {
            return new CrudResponseDto
            {
                Id = carro.Id,
                Modelo = carro.Modelo,
                Ativo = carro.Ativo
            };
        }
    }
}
