using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    public class SqlTest
    {
        [Test]
        public void Deve_criar_um_componente_numerodecimal_com_valor_23()
        {
            Tabela tabela = new Tabela("C14N006", null, "sql", null, "monetario", new Parametro("sql", "select valor from tabela where condicao = ''"));

            IComponente componente = new Sql(tabela, null, null);

            Assert.That(componente.Id(), Is.EqualTo("C14N006"));
        }
    }
}
