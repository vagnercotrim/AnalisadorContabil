using System;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    public class SqlTest
    {
        [Test]
        public void Deve_criar_um_componente_numerodecimal_com_valor_23()
        {
            IComponente componente = new Sql("C14-006", 23);

            Decimal valor = (Decimal)componente.GetValor();

            Assert.That(componente.Id(), Is.EqualTo("C14-006"));
            Assert.That(valor, Is.EqualTo(23));
        }
    }
}
