using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.NHibernate;
using AnalisadorContabil.Testes.Loader;
using AnalisadorContabil.Testes.Mock;
using AnalisadorContabil.Valor;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Testes.Integracao
{
    public class NHibernateFonteDeDadosTest : InMemoryDatabaseTest
    {
        private IDictionary<String, Tabela> _dados;
        private ITabelaDao _tabelaDao;
        private ConsultaSql _consultaSql;
        private ComponenteFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _dados = new Dictionary<String, Tabela>
            {
                { "C15N0010", new Tabela("C15N0010", "Retorna o valor da receita da empresa em um no periodo x do ano y.", "sql", "sqlite", new Parametro("sql", "SELECT ValorReceita FROM Conta WHERE Numero = '01.02.03.01' and Empresa = {empresa} and Ano = {ano} and Periodo = {periodo}"))},
                { "C15N0011", new Tabela("C15N0011", "Retorna o valor da despesa da empresa em um no periodo x do ano y.", "sql", "sqlite", new Parametro("sql", "SELECT ValorDespesa FROM Conta WHERE Numero = '01.02.03.01' and Empresa = {empresa} and Ano = {ano} and Periodo = {periodo}"))},
                { "C15N0020", new Tabela("C15N0020", "Retorna a diferença da receita e despeda.", "formula", "", new Parametro("formula", "[C15N0010] - [C15N0011]"))},
                { "C15N0021", new Tabela("C15N0021", "Verifica se deu lucro ou prejuízo.", "formula", "", new Parametro("formula", "[C15N0020] > 0 ? 'lucro' : 'prejuizo'"))},
                { "C15N0022", new Tabela("C15N0022", "Valor de receita em porcentagem de acordo com a maete de 150,00", "formula", "", new Parametro("formula", "porcentagem([C15N0010], 150.00)"))}
            };

            _tabelaDao = new TabelaDaoMock(_dados);

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
            IComponente consulta = _factory.Cria("C15N0010");

            IValor valor = consulta.GetValor();

            Assert.AreEqual(valor.Objeto(), 111.11M);
        }

        [Test]
        public void Deve_processar_o_componente_C15N0010_e_retornar_o_valor_111_00()
        {
            IComponente consulta = _factory.Cria("C15N0011");

            IValor valor = consulta.GetValor();

            Assert.AreEqual(valor.Objeto(), 111.00M);
        }

        [Test]
        public void Deve_processar_o_componente_formula_C15N0020_e_retornar_o_valor_0_11()
        {
            IComponente formula = _factory.Cria("C15N0020");

            IValor valor = formula.GetValor();

            Assert.AreEqual(valor.Objeto(), 0.11M);
        }

        [Test]
        public void Deve_processar_o_componente_formula_C15N0021_e_retornar_o_valor_lucro()
        {
            IComponente formula = _factory.Cria("C15N0021");

            IValor valor = formula.GetValor();

            Assert.AreEqual(valor.Objeto(), "lucro");
            Assert.AreEqual(valor.Exibir(), "lucro");
        }

        [Test]
        public void Deve_processar_o_componente_formula_C15N0022_com_funcao_porcentagem()
        {
            IComponente formula = _factory.Cria("C15N0022");

            IValor valor = formula.GetValor();

            Assert.AreEqual(Math.Round((decimal)valor.Objeto(),2), 74.07M);
        }
    }
}
