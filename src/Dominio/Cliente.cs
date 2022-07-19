using Dominio.Validadores;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Cliente
    {
        protected Cliente() { }

        public Cliente(string nome, string documento, string cep)
        {
            Nome = nome;
            Cep = cep;
            Documento = documento;
            ValidarPropriedades();
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Cep { get; private set; }
        public IEnumerable<PreVenda> PreVendas { get; private set; }

        public void AtualizarInformacoes(string nome, string cep)
        {
            Nome = nome;
            Cep = cep;
        }

        protected void ValidarPropriedades()
        {
            var resultado = ValidadorDeCliente.Builder.Validate(this);

            if (!resultado.IsValid)
            {
                var exceptions = new List<Exception>();

                foreach (var item in resultado.Errors)
                {
                    exceptions.Add(new Exception(item.ErrorMessage));
                }
                throw new AggregateException(exceptions);
            }
        }
    }
}
