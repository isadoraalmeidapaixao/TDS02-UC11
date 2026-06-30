using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace UtilitariosApp.Tests
{
    public class GerenciadorClientesTests
    {
        [Fact]
        public void AdicionarCliente_AoAdicionarCliente_DeveAumentarQuantidade()
        {
            var gerenciadorClientes = new GerenciadorClientes();
            var endereco = new Endereco("Rua B", 123, "São Paulo", "SP");
            var cliente = new Cliente(2, "Marcio", "marcio@mail.com", endereco);

            gerenciadorClientes.AdicionarCliente(cliente);

            Assert.Equal(1, gerenciadorClientes.ContarClientes());
        }

        [Fact]
        public void AdicionarCliente_ComClienteNulo_DeveLAncarArgumentNullExecption()
        {
            var gerenciador = new GerenciadorClientes();
            Assert.Throws<ArgumentNullException>(() => 
            gerenciador.AdicionarCliente(null));
        }
        [Fact]
        public void AdicionarCliente_VariosClientesValidos_DeveAdicionarTodos()
        {
            var gerenciador = new GerenciadorClientes();
            var endereco1 = new Endereco("Rua B", 123, "São Paulo", "SP");
            var cliente1 = new Cliente(1, "Silva", "silva@mail.com", endereco1);
            var endereco2 = new Endereco("Travessa X", 44, "São Paulo", "SP");
            var cliente2 = new Cliente(2, "Marcio", "marcio@mail.com", endereco2);

            gerenciador.AdicionarCliente(cliente1);
            gerenciador.AdicionarCliente(cliente2);

            Assert.Equal(2, gerenciador.ContarClientes());
        }

        [Fact]
        public void ProcurarPorId_ComClienteExistente_DeveRetornarCliente()
        {
            var gerenciador = new GerenciadorClientes();
            var endereco = new Endereco("Rua B", 123, "São Paulo", "SP");
            var cliente = new Cliente(1, "Silva", "silva@mail.com", endereco);
            
            gerenciador.AdicionarCliente(cliente);
            gerenciador.ProcurarPorId(1);

            Assert.NotNull(cliente);
            Assert.Equal(1, cliente.Id);
        }
    }
}
