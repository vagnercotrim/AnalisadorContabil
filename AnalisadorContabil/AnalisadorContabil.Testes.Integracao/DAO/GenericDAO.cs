using NHibernate;

namespace AnalisadorContabil.Testes.Integracao.DAO
{
    public class GenericDao<T> where T : class
    {

        private readonly ISession _session;

        public GenericDao(ISession session)
        {
            _session = session;
        }

        public void Save(T t)
        {
            _session.Save(t);
        }
    }
}