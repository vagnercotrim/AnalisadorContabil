using System;
using NHibernate;

namespace AnalisadorContabil.NHibernate
{
    public class ConsultaSql : IConsultaSql
    {
        private readonly ISession _session;

        public ConsultaSql(ISession session)
        {
            _session = session;
        }
        
        public object UniqueResult(String sql)
        {
            return _session.CreateSQLQuery(sql).UniqueResult();
        }
    }
}
