using NHibernate;
using System;

namespace AnalisadorContabil.Testes.Integracao
{
    public class ConsultaSql
    {
        private readonly ISession _session;

        public ConsultaSql(ISession session)
        {
            _session = session;
        }

        public object Retorno(String sql)
        {
            return _session.CreateSQLQuery(sql).UniqueResult();
        }
    }
}
