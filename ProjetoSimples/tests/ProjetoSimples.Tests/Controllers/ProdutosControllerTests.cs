using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoSimples.API.Controllers;
using ProjetoSimples.API.Models;
using ProjetoSimples.API.Services;


namespace ProjetoSimples.Tests.Controllers
{
    public class ProdutosControllerTests
    {
        [Fact]
        public void GetById_DeveRetornarOk_QuandoProdutoExistir()
        {
            var mockService = new Mock<IProdutoService>();

            //ensinamos ao mock como responder chamadas por id
            mockService.Setup(s => s.ObterPorId(40))
                .Returns(new Produto { Id = 1, Nome = "Mouse USB", Preco = 150.0m });
            
            var controller = new ProdutosController(mockService.Object);

            var result = controller.GetById(40);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var produtoRetornado = Assert.IsType<Produto>(okResult.Value);
            Assert.Equal("Mouse USB", produtoRetornado.Nome);
        }
    }
}
