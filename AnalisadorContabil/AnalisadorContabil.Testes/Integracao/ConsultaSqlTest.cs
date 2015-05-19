using AnalisadorContabil.NHibernate;
using AnalisadorContabil.Testes.Loader;
using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes.Integracao
{
    public class ConsultaSqlTest : InMemoryDatabaseTest
    {
        private IConsultaSql _consulta;

        [SetUp]
        public void SetUp()
        {
            ContaLoader contaLoader = new ContaLoader(Session);
            contaLoader.CriaContas();
        }

        [Test]
        public void Deve_retornar_valor_da_coluna_valorreceita_consulta_sql()
        {
            _consulta = new ConsultaSql(Session);

            Decimal valor = (decimal)_consulta.UniqueResult("SELECT ValorReceita FROM Conta WHERE Numero = '01.02.03.02'"); 

            Assert.AreEqual(valor, 222.22M);
        }

        [Test]
        public void Deve_retornar_valor_da_coluna_valordespesa_consulta_sql()
        {
            _consulta = new ConsultaSql(Session);

            Decimal valor = (decimal)_consulta.UniqueResult("SELECT ValorDespesa FROM Conta WHERE Numero = '01.02.03.02'");

            Assert.AreEqual(valor, 222.00M);
        }

    }
}