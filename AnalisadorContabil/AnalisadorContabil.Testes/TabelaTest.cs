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
            Tabela tabela1 = new Tabela("C15-0010", "Componente C15-0010", "sql", "tabela:gastos;selecione:valor1;campocondicao:conta;valorcondicao:01.02.03.04");
            
            IDictionary<String, object> parametros = tabela1.ToDictionary();

            Assert.AreEqual(parametros.Count, 4);
        }
    }
}
