using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CRUD.Domain.Entities
{
    internal class Carro
    {
        public int Id { get; private set; }
        public string Modelo { get; private set; }
        public bool Ativo { get; private set; } = true;

        protected Carro()
        {
        }
                        
        public Carro(int id, string modelo, bool ativo)
        {
            setModelo(modelo);
            setAtivo(ativo);
        }

        public void Atualizar(string modelo, bool ativo)
        {
            setModelo(modelo);
            setAtivo(ativo);
        } 
        public void Desativar (bool ativo)
        {
            ativo = false;
        }

        public void setModelo(string modelo)
        {
            if (string.IsNullOrEmpty(modelo))
                throw new Exception("não pode ser null");

            if (modelo.Length > 14)
                throw new Exception("não pode utrapassar o valor de 14 caracteres");

            modelo = modelo.ToLower();
        }

        public void setAtivo(bool ativo)
        {
            if (!ativo)
                ativo = true;
        }

    }
}
