using AnalisadorContabil.Testes.Integracao.DAO;
using AnalisadorContabil.Testes.Integracao.Models;
using NHibernate;

namespace AnalisadorContabil.Testes.Loader
{
    public class ContaLoader
    {
        private readonly ContaDao _contaDao;
        
        public ContaLoader(ISession session)
        {
            _contaDao = new ContaDao(session);
        }

        public void CriaContas()
        {
            Conta conta1 = new Conta { Numero = "01.02.03.01", ValorReceita = 111.11M, ValorDespesa = 111.00M, Empresa = 1, Ano = 2015, Periodo = 1 };
            Conta conta2 = new Conta { Numero = "01.02.03.02", ValorReceita = 222.22M, ValorDespesa = 222.00M, Empresa = 1, Ano = 2015, Periodo = 1 };
            Conta conta3 = new Conta { Numero = "01.02.03.03", ValorReceita = 333.33M, ValorDespesa = 333.00M, Empresa = 1, Ano = 2015, Periodo = 1 };

            _contaDao.Save(conta1);
            _contaDao.Save(conta2);
            _contaDao.Save(conta3);
        }
    }
}
