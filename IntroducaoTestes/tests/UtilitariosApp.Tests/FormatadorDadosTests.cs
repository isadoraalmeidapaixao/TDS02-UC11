using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosApp.Tests
{
    public class FormatadorDadosTests
    {
        [Theory]
        [InlineData(1234567890, "(123) 456-7890")]
        [InlineData(1111111111, "(111) 111-1111")]
        [InlineData(1211111111, "(121) 111-1111")]
        [InlineData(9999999999, "(999) 999-9999")]

        public void FormatarNumeroTelefone_AoReceberNumeroValido_DeveRetornarFormatado(double numero, string formatado)
        {
            var formatador = new FormatadorDados();
            var resultado = formatador.FormatarNumeroTelefone(numero);
            Assert.Equal(formatado, resultado);
        }
    }
}
