using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class FormulaFactoryTest
    {

        [Test]
        public void Deve_cria_um_componente_formula_atravez_de_formulafactory()
        {
            IDictionary<String, object> dados = new Dictionary<String, object>();
            dados.Add("C15-0010", "(25 * 3) / 15");

            IFonteDeDados fonteDeDados = new DictionaryFonteDeDados(dados);

            FormulaFactory formulaFactory = new FormulaFactory(fonteDeDados);

            Formula formula = formulaFactory.Criar("C15-0010");

            var valor = formula.GetValor();
            Assert.That(valor, Is.EqualTo(5));
        }

    }
}
