using System;
using AnalisadorContabil.Factory;
using AnalisadorContabil.Valor;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class ValorDataTest
    {
        [Test]
        public void Cria_objeto_valordata_com_valor_15_5_2015()
        {
            IValor valor = ValorFactory.Cria(new DateTime(2015, 5, 15), "{0:dd/MM/yyyy}");

            Assert.That(valor.Exibir(), Is.EqualTo("15/05/2015"));
        }

        [Test]
        public void Cria_objeto_valordata_com_valor_5_5_2015()
        {
            IValor valor = ValorFactory.Cria(new DateTime(2015, 5, 5), "{0:dd/MM/yyyy}");

            Assert.That(valor.Exibir(), Is.EqualTo("05/05/2015"));
        }
    }
}
