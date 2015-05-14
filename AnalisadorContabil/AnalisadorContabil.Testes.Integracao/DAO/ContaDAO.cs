using AnalisadorContabil.Testes.Integracao.Models;
using NHibernate;

namespace AnalisadorContabil.Testes.Integracao.DAO
{
    public class NotificacaoDao
    {
        private readonly GenericDao<Conta> _dao;

        public NotificacaoDao(ISession session)
        {
            _dao = new GenericDao<Conta>(session);
        }

        public void Save(Conta conta)
        {
            _dao.Save(conta);
        }
    }
}