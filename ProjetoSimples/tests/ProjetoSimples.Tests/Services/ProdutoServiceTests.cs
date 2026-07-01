using ProjetoSimples.API.Models;
using ProjetoSimples.API.Services;

namespace ProjetoSimples.Tests.Services
{
    public class ProdutoServiceTests
    {
        [Fact]
        public void Adicionar_DeveInserirProdutoERetornarComIdGerado()
        {
            var service = new ProdutoService();
            var produto = new Produto { Nome = "Mouse USB", Preco = 150.00m};

            var resultado = service.Adicionar(produto);

            Assert.True(resultado.Id > 0);
            Assert.Equal("Mouse USB", resultado.Nome);
            Assert.Single(service.ObterTodos());
        }
        [Fact]
        public void ObterPorId_DeveRetornarNuloQuandoProdutoNaoExistir()
        {
            var service = new ProdutoService();

            var resultado = service.ObterPorId(99);

            Assert.Null(resultado);
        }
    }
}
