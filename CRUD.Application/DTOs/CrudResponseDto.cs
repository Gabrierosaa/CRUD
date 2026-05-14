namespace CRUD.Application.DTOs
{
    public class CrudResponseDto
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}
