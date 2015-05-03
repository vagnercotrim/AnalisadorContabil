using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class ParametroTest
    {
        [Test]
        public void Deve_retornar_dois_parametros_de_uma_formula()
        {
            String formula = "[C14245] * 27 / 100";

            IList<String> parametros = Parametro.FromString(formula);

            Assert.That(parametros, Has.Member("C14245"));
        }
    }
}
