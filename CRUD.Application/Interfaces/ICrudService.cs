using CRUD.Application.DTOs;

namespace CRUD.Application.Interfaces
{
    public interface ICrudService
    {
        Task<List<CrudResponseDto>> GetAllAsync();
        Task<CrudResponseDto?> GetByIdAsync(int id);
        Task<CrudResponseDto> AddAsync(CrudCreateDto dto);
        Task<bool> UpdateAsync(int id, CrudUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
