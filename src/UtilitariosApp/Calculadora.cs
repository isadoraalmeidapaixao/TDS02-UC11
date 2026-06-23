using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosApp
{
    public class Calculadora
    {
        public int Somar(int a, int b)
        {
            return a + b;
        }
        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public int Dividir(double a, double b)
        {
            if (b == 0) return (int)a;
            var resultado = a / b;
            return (int)Math.Ceiling(resultado);
        }

        public int SubtrairPositivoOuZero(int a, int b)
        {
            if (a < b) return 0;
            return a - b;
        }

        public double PotenciaDeUmNumero(int @base, int expoente)
        {
            return Math.Pow(@base, expoente);
        }
    }
}