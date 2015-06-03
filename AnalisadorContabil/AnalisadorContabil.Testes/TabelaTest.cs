using AnalisadorContabil.Dominio;
using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class TabelaTest
    {
        [Test]
        public void Cria_um_parametro_com_decimal()
        {
            Tabela tabela = new Tabela("C15N0029", null, "formula", "dictionary", "{0:0.00}", new Parametro("numero", 23.23));
            object valor = tabela.Get("numero");

            Assert.That(valor, Is.EqualTo(23.23));
        }

        [Test]
        public void Cria_um_parametro_com_string()
        {
            Tabela tabela = new Tabela("C15N0029", null, "formula", "dictionary", "{0:0.00}", new Parametro("conta", "01.02.03"));
            object valor = tabela.Get("conta");

            Assert.That(valor, Is.EqualTo("01.02.03"));
        }

        [Test]
        public void Cria_um_parametro_com_data()
        {
            Tabela tabela = new Tabela("C15N0029", null, "formula", "dictionary", "{0:0.00}", new Parametro("prazo", new DateTime(2015, 04, 30)));
            object valor = tabela.Get("prazo");

            Assert.That(valor, Is.EqualTo(new DateTime(2015, 04, 30)));
        }

        [Test]
        public void Deve_retornar_nulo_quando_recupear_um_parametro_inexistente()
        {
            Tabela tabela = new Tabela("C15N0029", null, "formula", "dictionary", "{0:0.00}", new Parametro("numero", 23.23));
            object valor = tabela.Get("campo");

            Assert.That(valor, Is.Null);
        }
    }
}
