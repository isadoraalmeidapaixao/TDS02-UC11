using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosApp;

namespace UtilitariosApp.Tests
{

    public class CalculadoraTests
    {   
        [Fact]
        public void Somar_DeveRetornarASomaCorreta_()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Somar(5, 7);
            var resultadoZerado = calculadora.Somar(0, 0);

            Assert.Equal(12, resultado);
            Assert.Equal(0, resultadoZerado);
        }

        [Fact]
        public void multiplicar_DeveRetornarOProdutoCorreto()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Multiplicar(3, 3);

            Assert.Equal(9, resultado);
        }

        [Fact]
        public void Dividir_DeveRestornarOResultadoInteiroDaDivisaoArredondadoParaCima()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Dividir(3, 3);
            Assert.Equal(1, resultado);
        }
        [Fact]
        public void Dividir_AoDividirPorzero_DeveRetornarODividendo()
        {
            var calculadora = new Calculadora();
            var resultado = calculadora.Dividir(5, 0);
            Assert.Equal(5, resultado);
        }
    }
}
