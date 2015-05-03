using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class ComponenteFactoryTest
    {
        private IDictionary<String, Tabela> _dados;
        private TabelaDAO _dao;

        [SetUp]
        public void SetUp()
        {
            _dados = new Dictionary<String, Tabela>();

            Tabela tabela1 = new Tabela("C15-0010", null, "formula", "dictionary", new Parametro("formula", "(25 * 3)"));
            _dados.Add("C15-0010", tabela1);

            Tabela tabela2 = new Tabela("C15-0011", null, "formula", "dictionary", new Parametro("formula", "[C15-010] / 15"));
            _dados.Add("C15-0011", tabela2);

            _dao = new TabelaDAO(_dados);
        }

        [Test]
        public void Deve_criar_um_componente()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15-0010");

            Assert.AreEqual(formula.GetValor().Objeto(), 75.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_parametro()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15-0011");

            Assert.AreEqual(formula.GetValor().Objeto(), 5.00);
        }
    }
}
