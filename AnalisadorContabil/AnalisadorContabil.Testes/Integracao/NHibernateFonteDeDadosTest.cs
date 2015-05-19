using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.NHibernate;
using AnalisadorContabil.Testes.Loader;
using AnalisadorContabil.Valor;
using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes.Integracao
{
    public class NHibernateFonteDeDadosTest : InMemoryDatabaseTest
    {
        private ITabelaDao _tabelaDao;
        private IConsultaSql _consultaSql;
        private ComponenteFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _tabelaDao = new TabelaLoader().CriaTabelaDaoMock();

            ContaLoader contaLoader =  new ContaLoader(Session);
            contaLoader.CriaContas();

            _consultaSql = new ConsultaSql(Session);
            _factory = new ComponenteFactory(_tabelaDao);
            _factory.AdicionaFonte("sqlite", new NHibernateFonteDeDados(_consultaSql));

            _factory.AdicionaVariavelSistema("empresa", 1);
            _factory.AdicionaVariavelSistema("ano", 2015);
            _factory.AdicionaVariavelSistema("periodo", 1);
        }

        [Test]
        public void Deve_processar_o_componente_C15N0010_e_retornar_o_valor_111_11()
        {
            IComponente consulta = _factory.Cria("C15N0050");

            IValor valor = consulta.GetValor();

            Assert.AreEqual(valor.Objeto(), 111.11M);
        }

        [Test]
        public void Deve_processar_o_componente_C15N0010_e_retornar_o_valor_111_00()
        {
            IComponente consulta = _factory.Cria("C15N0051");

            IValor valor = consulta.GetValor();

            Assert.AreEqual(valor.Objeto(), 111.00M);
        }

        [Test]
        public void Deve_processar_o_componente_formula_C15N0020_e_retornar_o_valor_0_11()
        {
            IComponente formula = _factory.Cria("C15N0060");

            IValor valor = formula.GetValor();

            Assert.AreEqual(valor.Objeto(), 0.11M);
        }

        [Test]
        public void Deve_processar_o_componente_formula_C15N0021_e_retornar_o_valor_lucro()
        {
            IComponente formula = _factory.Cria("C15N0061");

            IValor valor = formula.GetValor();

            Assert.AreEqual(valor.Objeto(), "lucro");
            Assert.AreEqual(valor.Exibir(), "lucro");
        }

        [Test]
        public void Deve_processar_o_componente_formula_C15N0022_com_funcao_porcentagem()
        {
            IComponente formula = _factory.Cria("C15N0062");

            IValor valor = formula.GetValor();

            Assert.AreEqual(Math.Round((decimal)valor.Objeto(),2), 74.07M);
        }

        [Test]
        public void Deve_processar_o_componente_formula_C15N0052_e_retornar_nulo()
        {
            IComponente formula = _factory.Cria("C15N0052");

            IValor valor = formula.GetValor();

            Assert.AreEqual(valor.Objeto(), null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Deve_retornar_uma_exception_tentanto_criar_um_componente_que_nao_existe()
        {
            IComponente formula = _factory.Cria("C00N9999");
        }
    }
}
