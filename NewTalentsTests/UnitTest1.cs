using System;
using Xunit;
using NewTalents;

namespace NewTalentsTests
{
    public class UnitTest1
    {
        Calculadora calc = new Calculadora("27/05/2024"); //estamos instanciando nossa classe Calculadora dentro da classe UnitTest1; desta forma,
                                                          //a classe calculadora pode ser utilizada em qualquer lugar dentro da nossa classe UnitTest1;
                                                          //poder�amos tamb�m fazer a refer�ncia dentro de cada m�todo ao inv�s de fazer globalmente.

        [Fact] //teste unit�rio
        public void DeveSomar1com2EResultar3()
        {
            //Calculadora calc = new Calculadora(); --------- instancia��o da nossa classe Calculadora dentro do m�todo de teste
            int resultado = calc.somar(1, 2);
            Assert.Equal(3, resultado);
        }

        [Theory] //teste m�ltiplo
        [InlineData(1, 2, 3)]
        [InlineData(97, 2, 99)]
        [InlineData(10, 20, 30)]
        [InlineData(5, 17, 22)]
        public void TestesMultiplosDeSoma(int valor1, int valor2, int resultado)
        {
            //Calculadora calc = new Calculadora(); --------- instancia��o da nossa classe Calculadora dentro do m�todo de teste
            int resultadoCalculadora = calc.somar(valor1, valor2);
            Assert.Equal(resultadoCalculadora, resultado);
        }

        [Theory] //teste m�ltiplo
        [InlineData(2, 1, 1)]
        [InlineData(97, 27, 70)]
        [InlineData(65, 37, 28)]
        [InlineData(99, 99, 0)]
        public void TestesMultiplosDeSubtracao(int valor1, int valor2, int resultado)
        {
            //Calculadora calc = new Calculadora(); --------- instancia��o da nossa classe Calculadora dentro do m�todo de teste
            int resultadoCalculadora = calc.subtrair(valor1, valor2);
            Assert.Equal(resultadoCalculadora, resultado);
        }

        [Theory] //teste m�ltiplo
        [InlineData(2, 24, 48)]
        [InlineData(31, 3, 93)]
        [InlineData(25, 2, 50)]
        [InlineData(60, 1, 60)]
        public void TestesMultiplosDeMultiplicacao(int valor1, int valor2, int resultado)
        {
            //Calculadora calc = new Calculadora(); --------- instancia��o da nossa classe Calculadora dentro do m�todo de teste
            int resultadoCalculadora = calc.multiplicar(valor1, valor2);
            Assert.Equal(resultadoCalculadora, resultado);
        }

        [Theory] //teste m�ltiplo
        [InlineData(48, 2, 24)]
        [InlineData(30, 3, 10)]
        [InlineData(75, 3, 25)]
        [InlineData(99, 3, 33)]
        public void TestesMultiplosDeDividir(int valor1, int valor2, int resultado)
        {
            //Calculadora calc = new Calculadora(); --------- instancia��o da nossa classe Calculadora dentro do m�todo de teste
            int resultadoCalculadora = calc.dividir(valor1, valor2);
            Assert.Equal(resultadoCalculadora, resultado);
        }

        [Fact]
        public void DivisaoPorZero()
        {
            Assert.Throws<DivideByZeroException>(() => calc.dividir(3, 0));
        }

        [Fact]
        public void TestarHistorico()
        {
            calc.somar(1, 2);
            calc.subtrair(61, 1);
            calc.multiplicar(2, 2);
            calc.dividir(6, 2);

            var lista = calc.historico();
            Assert.NotEmpty(calc.historico());
            Assert.Equal(3, lista.Count);
        }
    }
}
