using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class NumeroDecimalTest
    {

        [Test]
        public void Deve_criar_um_componente_numerodecimal_com_valor_23()
        {
            IComponente componente = new NumeroDecimal("C14-005", 23);
            
            Decimal valor = (Decimal)componente.GetValor();

            Assert.That(componente.Id(), Is.EqualTo("C14-005"));
            Assert.That(valor, Is.EqualTo(23));
        }

    }
}
