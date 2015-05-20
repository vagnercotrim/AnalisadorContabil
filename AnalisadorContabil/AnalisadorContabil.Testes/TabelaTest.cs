using AnalisadorContabil.Dominio;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class TabelaTest
    {
        [Test]
        public void Cria_objeto_da_classe_tabela_com_4_parametros()
        {
            const string json = "[{\"Nome\":\"tabela\",\"Valor\":\"gastos\"},{\"Nome\":\"selecione\",\"Valor\":\"valor1\"},{\"Nome\":\"campocondicao\",\"Valor\":\"conta\"},{\"Nome\":\"valorcondicao\",\"Valor\":\"01.02.03.04\"}]";

            Tabela tabela1 = new Tabela("C15N0029", "Componente C15N0029", "sql", "dictionary", "numerico", json);

            IList<Parametro> parametros = tabela1.ParametrosToList();

            Assert.AreEqual(parametros.Count, 4);
        }

        [Test]
        public void Cria_um_parametro_com_decimal()
        {
            Tabela tabela = new Tabela("C15N0029", null, "formula", "dictionary", "numerico", new Parametro("numero", 23.23));
            object valor = tabela.Get("numero");

            Assert.That(valor, Is.EqualTo(23.23));
        }

        [Test]
        public void Cria_um_parametro_com_string()
        {
            Tabela tabela = new Tabela("C15N0029", null, "formula", "dictionary", "numerico", new Parametro("conta", "01.02.03"));
            object valor = tabela.Get("conta");

            Assert.That(valor, Is.EqualTo("01.02.03"));
        }

        [Test]
        public void Cria_um_parametro_com_data()
        {
            Tabela tabela = new Tabela("C15N0029", null, "formula", "dictionary", "numerico", new Parametro("prazo", new DateTime(2015, 04, 30)));
            object valor = tabela.Get("prazo");

            Assert.That(valor, Is.EqualTo(new DateTime(2015, 04, 30)));
        }

        [Test]
        public void Deve_retornar_nulo_quando_recupear_um_parametro_inexistente()
        {
            Tabela tabela = new Tabela("C15N0029", null, "formula", "dictionary", "numerico", new Parametro("numero", 23.23));
            object valor = tabela.Get("campo");

            Assert.That(valor, Is.Null);
        }
    }
}
