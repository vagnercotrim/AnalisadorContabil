using AnalisadorContabil.Factory;
using AnalisadorContabil.Valor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class ValorDecimalTest
    {

        public ValorDecimalTest()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
        }

        [Test]
        public void Cria_objeto_valordecimal_com_formatacao_porcentagem()
        {
            IValor valor = ValorFactory.Cria(34.56M, "{0:0.00}%");

            Assert.That(valor.Exibir(), Is.EqualTo("34,56%"));
        }

        [Test]
        public void Cria_objeto_valordecimal_com_formatacao_de_monetario()
        {
            IValor valor = ValorFactory.Cria(34.56M, "R$ {0:0.00}");

            Assert.That(valor.Exibir(), Is.EqualTo("R$ 34,56"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cria_objeto_valordecimal_com_formatacao_nulo()
        {
            IValor valor = ValorFactory.Cria(34.56M, null);

            Assert.That(valor.Exibir(), Is.Empty);
        }
    }
}
