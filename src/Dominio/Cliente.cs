using System;

namespace Dominio
{
    public class Cliente
    {
        protected Cliente() { }

        public Cliente(string nome, string documento, string cep)
        {
            Nome = nome;
            Documento = documento;
            Cep = cep;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Cep { get; private set; }

        public void AtualizarInformacoes(string nome, string documento, string cep)
        {
            Nome = nome;
            Documento = documento;
            Cep = cep;
        }
    }
}
