using System;

namespace AnalisadorContabil.NHibernate
{
    public interface IConsultaSql
    {
        object UniqueResult(String sql);
    }
}