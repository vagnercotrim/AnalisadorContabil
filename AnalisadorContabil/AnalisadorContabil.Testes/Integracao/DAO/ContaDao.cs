using AnalisadorContabil.Testes.Integracao.Models;
using NHibernate;
using System.Collections.Generic;

namespace AnalisadorContabil.Testes.Integracao.DAO
{
    public class ContaDao
    {
        private readonly GenericDao<Conta> _dao;

        public ContaDao(ISession session)
        {
            _dao = new GenericDao<Conta>(session);
        }

        public void Save(Conta conta)
        {
            _dao.Save(conta);
        }

        public IEnumerable<Conta> Todas()
        {
            return _dao.GetAll();
        }
    }
}