using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
