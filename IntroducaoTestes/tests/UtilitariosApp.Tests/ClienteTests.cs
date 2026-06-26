using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosApp.Tests
{
    public class ClienteTests
    {
        [Fact]
        public void Cliente_DeveTerPropriedadesCorretas()
        {
            var endereco = new Endereco("Rua Tito", 123, "São Paulo", "SP");
            int id = 87;
            string nome = "Souza Santos";
            string email = "Souza.santos@mail.com";

            var cliente = new Cliente(id, nome, email, endereco);

            Assert.NotNull(cliente);
            Assert.Equal(id, cliente.Id);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(email, cliente.Email);
            Assert.NotNull(endereco);
        }

        [Fact]
        public void Cliente_DeveContribuirEnderecoCorreto()
        {
            var endereco = new Endereco("Rua Tito", 54, "São Paulo", "SP");
            int id = 87;
            string nome = "Souza Santos";
            string email = "Souza.santos@mail.com";

            var cliente = new Cliente(id, nome, email, endereco);
            var enderecoFormatado = cliente.Enderco.FormatarEndereco();

            Assert.Equal("Rua Tito, 54, São Paulo, SP", enderecoFormatado);
        }

        [Fact]
        public void EmailValido_ComEmailCorreto_DeveRetornar_Verdadeiro()
        {
            var endereco = new Endereco("Rua Tito", 54, "São Paulo", "SP");
            int id = 87;
            string nome = "Souza Santos";
            string email = "Souza.santos@mail.com";

            var cliente = new Cliente(id, nome, email, endereco);

            Assert.True(cliente.EmailValido());
        }
        [Fact]
        public void EmailValido_SemArroba_DeveRetornar_Falso()
        {
            var endereco = new Endereco("Rua Tito", 54, "São Paulo", "SP");
            int id = 87;
            string nome = "Souza Santos";
            string email = "Souza.santosmail.com";

            var cliente = new Cliente(id, nome, email, endereco);

            Assert.False(cliente.EmailValido());

        }
        [Fact]
        public void EmailValido_SemPonto_DeveRetornar_Falso()
        {
            var endereco = new Endereco("Rua Tito", 54, "São Paulo", "SP");
            int id = 87;
            string nome = "Souza Santos";
            string email = "souzasantos@mail-com";

            var cliente = new Cliente(id, nome, email, endereco);

            Assert.False(cliente.EmailValido());
        }
    }
}
