using AnalisadorContabil.Dominio;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class ParametroTest
    {
        [Test]
        public void Deve_retornar_dois_parametros_de_uma_formula()
        {
            const string formula = "[C14245] * 27 / 100";

            IList<String> parametros = Parametro.FromString(formula);

            Assert.That(parametros, Has.Member("C14245"));
        }
    }
}
