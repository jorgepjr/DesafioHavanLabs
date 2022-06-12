﻿using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using Refit;
using System.Threading.Tasks;

namespace CasosDeUso.Enderecos
{
    public class BuscarEndereco : CasoDeUsoBase
    {
        private readonly IApiViaCep apiViaCep;

        public BuscarEndereco(IApiViaCep apiViaCep)
        {
            this.apiViaCep = apiViaCep;
        }

        public async Task<EnderecoDto> Executar(string cep)
        {
            EnderecoDto enderecoDto;

            try
            {
                enderecoDto = await apiViaCep.BuscarEndereco(cep);

                if(enderecoDto is null)
                {
                    Erros.Add("Erro", "Endereço não encontrado!");
                    return null;
                }
            }
            catch (ApiException ex)
            {
                Erros.Add(ex.StatusCode.ToString(), ex.Message);
                return null;
            }

            return enderecoDto;
        }
    }
}