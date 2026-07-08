using ControleEstoque.API.Controllers;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ControleEstoque.API.Tests.Controllers
{
    public  class UsuariosControllerTests
    {
        [Fact]
        public async Task Autenticar_QuandoCredencialInvalida_RetornaUnauthorized()
        {
            var login = new LoginDto { Email = "teste@mail.com", Senha = "senha" };
            var loginCorreto = new LoginDto { Email = "teste@mail.com", Senha = "senha123" };
            var service = new Mock<IUsuarioService>();
            service.Setup(s => s.AutenticarAsync(loginCorreto)).ReturnsAsync((TokenDto?)null);
            var controller = new UsuariosController(service.Object);

            var result = await controller.Autenticar(login);

            var unauthorized = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Login ou Senha Incorretos!", unauthorized.Value?.ToString());
        }
        [Fact]
        public async Task RegistrarCliente_QuandoSucesso_DeveRetornarCreatedAtAction()
        {
            var criarClienteDto = new CriarClienteDto {
                Nome = "Teste",
                CPF = "12345678900",
                Email = "teste@mail.com", 
                Senha = "senha" };

            var service = new Mock<IUsuarioService>();
            service.Setup(s => s.RegistrarClienteAsync(criarClienteDto)).ReturnsAsync(new UsuarioDto {
                Id = 1,
                Nome = "Teste",
                CPF = "12345678900",
                Email = "teste@mail.com",
            });

            var controller = new UsuariosController(service.Object);

            var result = await controller.RegistrarCliente(criarClienteDto);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("12345678900", ((UsuarioDto)createdResult.Value!).CPF);
        }
    }
}
