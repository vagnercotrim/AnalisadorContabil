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

            IList<String> parametros = Parametro.ReferenciasComponente(formula);

            Assert.That(parametros, Has.Member("C14245"));
        }

        [Test]
        public void Verifica_a_expressao_eegular()
        {
            const string formula = "[C1_15-1234] + [C1015-1234] + [C1_1501234] + [C101501234]";

            IList<String> parametros = Parametro.ReferenciasComponente(formula);

            Assert.AreEqual(parametros.Count, 4);
        }
    }
}
