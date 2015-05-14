using System.Linq;
using AnalisadorContabil.Testes.Integracao.DAO;
using AnalisadorContabil.Testes.Integracao.Models;
using NUnit.Framework;

namespace AnalisadorContabil.Testes.Integracao
{
    [TestFixture]
    public class InsereDadosNoBanco : InMemoryDatabaseTest
    {
        private ContaDao _dao;

        [SetUp]
        public void SetUp()
        {
            _dao = new ContaDao(Session);
        }

        [Test]
        public void Salva_uma_conta_no_banco()
        {
            Conta conta = new Conta { Numero = "01.02.03.04.05.06.07.08", ValorReceita = 12345.56M, ValorDespesa = 2457.58M, Empresa = 1, Ano = 2015, Periodo = 1};

            _dao.Save(conta);

            Assert.AreEqual(_dao.Todas().Count(), 1);
        }
    }
}
