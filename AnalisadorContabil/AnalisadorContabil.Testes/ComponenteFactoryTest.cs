using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
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

            Tabela tabela1 = new Tabela("C15N0010", null, "formula", "dictionary", new Parametro("formula", "(25 * 3)"));
            _dados.Add("C15N0010", tabela1);

            Tabela tabela2 = new Tabela("C15N0011", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] / 15"));
            _dados.Add("C15N0011", tabela2);

            Tabela tabela3 = new Tabela("C15N0013", null, "formula", "dictionary", new Parametro("formula", "[C15N0011] * 3"));
            _dados.Add("C15N0013", tabela3);

            Tabela tabela4 = new Tabela("C15N0014", null, "formula", "dictionary", new Parametro("formula", "5 * 5"));
            _dados.Add("C15N0014", tabela4);

            Tabela tabela5 = new Tabela("C15N0015", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] + [C15N0014]"));
            _dados.Add("C15N0015", tabela5);

            Tabela tabela6 = new Tabela("C15N0016", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] + [C15N0013]"));
            _dados.Add("C15N0016", tabela6);

            Tabela tabela7 = new Tabela("C15N0027", null, "sql", "dictionary",
                new List<Parametro>()
                {
                    new Parametro("tabela", "tabela"),
                    new Parametro("campo", "campo"),
                    new Parametro("condicao", "condicao"),
                    new Parametro("valor", "'02.01.03'")
                });
            _dados.Add("C15N0027", tabela7);

            Tabela tabela8 = new Tabela("C15N0028", null, "formula", "dictionary", new Parametro("formula", "[C15N0027] - 23000"));
            _dados.Add("C15N0028", tabela8);

            _dao = new TabelaDAO(_dados);
        }

        [Test]
        public void Deve_criar_um_componente()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0010");

            Assert.AreEqual(formula.GetValor().Objeto(), 75.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_parametro()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0011");

            Assert.AreEqual(formula.GetValor().Objeto(), 5.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_parametros()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0013");

            Assert.AreEqual(formula.GetValor().Objeto(), 15.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_dois_parametros()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0015");

            Assert.AreEqual(formula.GetValor().Objeto(), 100.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_dois_parametros_outra_formula()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0016");

            Assert.AreEqual(formula.GetValor().Objeto(), 90.00);
        }

        [Test]
        public void Deve_criar_um_componente_sql()
        {
            IDictionary<String, object> resultadoDoComponente = new Dictionary<String, object>();
            resultadoDoComponente.Add("C15N0027", 23456.78);

            ComponenteFactory factory = new ComponenteFactory(_dao);
            factory.AdicionaFonte("dictionary", new DictionaryFonteDeDados(resultadoDoComponente));

            IComponente formula = factory.Cria("C15N0027");

            IValor valor = formula.GetValor();

            Assert.AreEqual(valor.Objeto(), 23456.78);
        }

        [Test]
        public void Deve_criar_um_componente_formula_que_usa_componete_sql()
        {
            IDictionary<String, object> resultadoDoComponente = new Dictionary<String, object>();
            resultadoDoComponente.Add("C15N0027", 23456.78M);

            ComponenteFactory factory = new ComponenteFactory(_dao);
            factory.AdicionaFonte("dictionary", new DictionaryFonteDeDados(resultadoDoComponente));

            IComponente formula = factory.Cria("C15N0028");

            IValor valor = formula.GetValor();

            Assert.AreEqual(valor.Objeto(), 456.78);
        }

    }
}
