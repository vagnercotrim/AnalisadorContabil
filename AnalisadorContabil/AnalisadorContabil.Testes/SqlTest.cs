using AnalisadorContabil.Componente;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    public class SqlTest
    {
        [Test]
        public void Deve_criar_um_componente_numerodecimal_com_valor_23()
        {
            IComponente componente = new Sql("C14N006", "select valor from tabela where condicao = ''", "numerico", null);

            Assert.That(componente.Id(), Is.EqualTo("C14N006"));
        }
    }
}
