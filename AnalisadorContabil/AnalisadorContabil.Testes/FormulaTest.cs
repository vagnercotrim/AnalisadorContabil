using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class FormulaTest
    {

        [Test]
        public void Deve_criar_um_componente_formula_e_retornar_75()
        {
            IComponente componente = new Formula("C14-006", "25 * 3");

            var valor = componente.GetValor();

            Assert.That(valor, Is.EqualTo(75));
        }

    }
}
