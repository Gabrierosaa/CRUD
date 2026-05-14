namespace CRUD.Domain.Entities
{
    public class Carro
    {
        public int Id { get; private set; }
        public string Modelo { get; private set; } = string.Empty;
        public bool Ativo { get; private set; } = true;

        protected Carro()
        {
        }

        public Carro(int id, string modelo, bool ativo)
        {
            Id = id;
            SetModelo(modelo);
            SetAtivo(ativo);
        }

        public void Atualizar(string modelo, bool ativo)
        {
            SetModelo(modelo);
            SetAtivo(ativo);
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void DefinirId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O id deve ser maior que zero.", nameof(id));

            Id = id;
        }

        private void SetModelo(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("O modelo nao pode ser vazio.", nameof(modelo));

            if (modelo.Length > 14)
                throw new ArgumentException("O modelo nao pode ultrapassar 14 caracteres.", nameof(modelo));

            Modelo = modelo.Trim().ToLower();
        }

        private void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }
    }
}
