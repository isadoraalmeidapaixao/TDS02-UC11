using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosApp;

namespace UtilitariosApp
{
    public class GerenciadorClientes
    {
        private List<Cliente> clientes = new();
        public void AdicionarCliente(Cliente cliente)
        {
            // Lógica para adicionar o cliente
        }

        public List<Cliente> ObterTodosClientes()
        {
            return clientes;
        }
    }
}
