namespace CRUD.Application.DTOs
{
    internal class CrudResponseDto
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}
