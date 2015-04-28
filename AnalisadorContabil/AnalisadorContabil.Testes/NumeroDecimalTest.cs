using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class NumeroDecimalTest
    {

        [Test]
        public void Deve_criar_um_componente_numerodecimal_com_valor_23()
        {
            IComponente componente = new NumeroDecimal(23);

            Decimal valor = (Decimal)componente.GetValor();

            Assert.That(valor, Is.EqualTo(23));
        }

    }
}
