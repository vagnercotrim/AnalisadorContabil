using AnalisadorContabil.Componente;
using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class SqlFactoryTest
    {
        [Test]
        public void Deve_cria_um_componente_formula_atravez_de_formulafactory()
        {
            IDictionary<String, Tabela> dados = new Dictionary<String, Tabela>();
            dados.Add("C15-0010", new Tabela("C15-0010", null, "sql", "resultado:23,23;tiporetorno:'decimal'", null));

            IFonteDeDados fonteDeDados = new DictionaryFonteDeDados(dados);

            SqlFactory formulaFactory = new SqlFactory(fonteDeDados);

            Sql formula = formulaFactory.Criar("C15-0010");

            var valor = formula.GetValor();
            Assert.That(valor.Exibir(), Is.EqualTo("23,23"));
        }
    }
}
