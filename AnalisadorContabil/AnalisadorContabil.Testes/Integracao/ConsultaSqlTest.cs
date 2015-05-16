using AnalisadorContabil.NHibernate;
using AnalisadorContabil.Testes.Integracao.DAO;
using AnalisadorContabil.Testes.Integracao.Models;
using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes.Integracao
{
    public class ConsultaSqlTest : InMemoryDatabaseTest
    {
        private ContaDao _dao;
        private IConsultaSql _consulta;

        [SetUp]
        public void SetUp()
        {
            _dao = new ContaDao(Session);

            Conta conta1 = new Conta { Numero = "01.02.03.01", ValorReceita = 111.11M, ValorDespesa = 111.00M, Empresa = 1, Ano = 2015, Periodo = 1 };
            Conta conta2 = new Conta { Numero = "01.02.03.02", ValorReceita = 222.22M, ValorDespesa = 222.00M, Empresa = 1, Ano = 2015, Periodo = 1 };
            Conta conta3 = new Conta { Numero = "01.02.03.03", ValorReceita = 333.33M, ValorDespesa = 333.00M, Empresa = 1, Ano = 2015, Periodo = 1 };

            _dao.Save(conta1);
            _dao.Save(conta2);
            _dao.Save(conta3);
        }

        [Test]
        public void Deve_retornar_valor_da_coluna_valorreceita_consulta_sql()
        {
            _consulta = new ConsultaSql(Session);

            Decimal valor = (decimal)_consulta.UniqueResult("SELECT ValorReceita FROM Conta WHERE Numero = '01.02.03.01'"); 

            Assert.AreEqual(valor, 111.11M);
        }

        [Test]
        public void Deve_retornar_valor_da_coluna_valordespesa_consulta_sql()
        {
            _consulta = new ConsultaSql(Session);

            Decimal valor = (decimal)_consulta.UniqueResult("SELECT ValorDespesa FROM Conta WHERE Numero = '01.02.03.01'");

            Assert.AreEqual(valor, 111.00M);
        }

    }
}