using CasosDeUso.Produtos;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.ProdutoTeste
{
    public class EditarProdutoTeste : PersistenciasMock
    {
       
        [Fact]
        public async Task DeveEditarInformacoesDoProduto()
        {
            //Arrange
            var editarProdutoDto = ModelsMock.EditarProdutoDtoMock;
            var (persistenciaDoProduto, produto) = PersistenciaDoProdutoBuscarPorIdMock(editarProdutoDto.ProdutoId);
            
            var editarProduto = new EditarProduto(persistenciaDoProduto.Object);

            //Action
            await editarProduto.Executar(editarProdutoDto);

            //Assert
            persistenciaDoProduto.Verify(x => x.Atualizar(produto), Times.Once());
        }
    }
}
