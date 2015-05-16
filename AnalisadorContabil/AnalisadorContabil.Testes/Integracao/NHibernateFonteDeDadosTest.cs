using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.NHibernate;
using AnalisadorContabil.Testes.Integracao.DAO;
using AnalisadorContabil.Testes.Integracao.Models;
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
        private ContaDao _contaDao;

        [SetUp]
        public void SetUp()
        {
            _dados = new Dictionary<String, Tabela>();

            Tabela tabela1 = new Tabela("C15N0010", "Retorna o valor da receita da empresa em um no periodo x do ano y.", "sql", "sqlite", new Parametro("sql", "SELECT ValorReceita FROM Conta WHERE Numero = '01.02.03.01'"));
            _dados.Add("C15N0010", tabela1);

            _tabelaDao = new TabelaDaoMock(_dados);

            _contaDao = new ContaDao(Session);

            Conta conta1 = new Conta { Numero = "01.02.03.01", ValorReceita = 111.11M, ValorDespesa = 111.00M, Empresa = 1, Ano = 2015, Periodo = 1 };
            Conta conta2 = new Conta { Numero = "01.02.03.02", ValorReceita = 222.22M, ValorDespesa = 222.00M, Empresa = 1, Ano = 2015, Periodo = 1 };
            Conta conta3 = new Conta { Numero = "01.02.03.03", ValorReceita = 333.33M, ValorDespesa = 333.00M, Empresa = 1, Ano = 2015, Periodo = 1 };

            _contaDao.Save(conta1);
            _contaDao.Save(conta2);
            _contaDao.Save(conta3);
        }

        [Test]
        public void Deve_criar_um_componente_formula_que_usa_componete_sql()
        {
            ConsultaSql consultaSql = new ConsultaSql(Session);

            ComponenteFactory factory = new ComponenteFactory(_tabelaDao);
            factory.AdicionaFonte("sqlite", new NHibernateFonteDeDados(consultaSql));

            IComponente consulta = factory.Cria("C15N0010");

            IValor valor = consulta.GetValor();

            Assert.AreEqual(valor.Objeto(), 111.11M);
        }

    }
}
