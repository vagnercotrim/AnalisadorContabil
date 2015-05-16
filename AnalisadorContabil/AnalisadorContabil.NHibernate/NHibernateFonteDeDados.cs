using AnalisadorContabil.FonteDeDados;
using System;

namespace AnalisadorContabil.NHibernate
{
    public class NHibernateFonteDeDados : IFonteDeDados
    {
        private readonly IConsultaSql _consulta;

        public NHibernateFonteDeDados(IConsultaSql consulta)
        {
            _consulta = consulta;
        }

        public object GetDados(String sql)
        {
            return _consulta.UniqueResult(sql);
        }
    }
}
