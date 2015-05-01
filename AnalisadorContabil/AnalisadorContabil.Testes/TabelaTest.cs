using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalisadorContabil.Componente;
using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class TabelaTest
    {
        [Test]
        public void Cria_objeto_da_classe_tabela_com_4_parametros()
        {
            String json = "[{\"Nome\":\"tabela\",\"Valor\":\"gastos\"},{\"Nome\":\"selecione\",\"Valor\":\"valor1\"},{\"Nome\":\"campocondicao\",\"Valor\":\"conta\"},{\"Nome\":\"valorcondicao\",\"Valor\":\"01.02.03.04\"}]";
            
            Tabela tabela1 = new Tabela("C15-0010", "Componente C15-0010", "sql", json);

            IList<Parametro> parametros = tabela1.ParametrosToList();

            Assert.AreEqual(parametros.Count, 4);
        }

        [Test]
        public void Cria_um_parametro_com_decimal()
        {
            Tabela tabela = new Tabela("C15-0010", null, "formula", new Parametro("numero", 23.23));
            object valor = tabela.Get("numero");

            Assert.That(valor, Is.EqualTo(23.23));
        }

        [Test]
        public void Cria_um_parametro_com_string()
        {
            Tabela tabela = new Tabela("C15-0010", null, "formula", new Parametro("conta", "01.02.03"));
            object valor = tabela.Get("conta");

            Assert.That(valor, Is.EqualTo("01.02.03"));
        }

        [Test]
        public void Cria_um_parametro_com_data()
        {
            Tabela tabela = new Tabela("C15-0010", null, "formula", new Parametro("prazo", new DateTime(2015,04,30)));
            object valor = tabela.Get("prazo");

            Assert.That(valor, Is.EqualTo(new DateTime(2015, 04, 30)));
        }

    }
}
