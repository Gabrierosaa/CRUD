using CRUD.Application.DTOs;

namespace CRUD.Application.Interfaces
{
    internal class ICrudService
    {
        Task<List<CrudResponseDto>> GetAllAsync();
        Task<CrudResponseDto?> GetByIdAsync(int id);
        Task AddAsync(CrudResponseDto dto);
        void Update(int id, CrudUpdateDto dto);
        void Delete(int id);
    }
}
