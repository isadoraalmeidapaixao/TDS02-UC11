using ControleEstoque.API.Controllers;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ControleEstoque.API.Tests.Controllers
{
    public class ProdutosControllerTests
    {
        [Fact]
        public async Task GetById_ProdutoNaoEncontrado_DeveRetornarNotFound()
        {
            var serviceMock = new Mock<IProdutoService>();
            serviceMock.Setup(sm => sm.ObterPorIdAsync(23))
                .ReturnsAsync((ProdutoDto?)null);
            var controller = new ProdutosController(serviceMock.Object);

            var result = await controller.GetById(23);

            Assert.IsType<NotFoundResult>(result);

        }
        [Fact]
        public async Task Create_ProdutoCriado_DeveRetornarCreatedAtAction()
        {
            var produtoDto = new CriarProdutoDto
            {
                Nome = "Teclado",
                Preco = 99.90m,
                FornecedorId = 1,
                QuantidadeEstoque = 30
            };
            var produtoRetornadoDaService = new ProdutoDto
            {
                Id = 23,
                Nome = "Teclado",
                Preco = 99.90m,
                FornecedorId = 1,
                QuantidadeEstoque = 30
            };

            var serviceMock = new Mock<IProdutoService>();
            serviceMock.Setup(s => s.CriarAsync(produtoDto)).ReturnsAsync(produtoRetornadoDaService);

            var controller = new ProdutosController(serviceMock.Object);

            var result = await controller.Create(produtoDto);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(23, ((ProdutoDto)createdResult.Value!).Id);
            Assert.Equal("Teclado", ((ProdutoDto)createdResult.Value!).Nome);
        }
        [Fact]
        public async Task Update_IdDiferente_DeveRetornarBadRequest()
        {
            var serviceMock = new Mock<IProdutoService>();

            var produtoParaAtualizar = new AtualizarProdutoDto
            {
                Id = 1,
                Nome = "Teclado Mecanico RGB",
                Preco = 599.90m,
                FornecedorId = 1,
                QuantidadeEstoque = 30
            };

            var controller = new ProdutosController(serviceMock.Object);

            var result = await controller.Update(2, produtoParaAtualizar);

            var badRequest = Assert.IsType<BadRequestResult>(result);

        }
    }
}
