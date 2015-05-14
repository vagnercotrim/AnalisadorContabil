using AnalisadorContabil.FonteDeDados;
using System;

namespace AnalisadorContabil.NHibernate
{
    public class NHibernateFonteDeDados : IFonteDeDados
    {
        private readonly ConsultaSql _consulta;
        
        public NHibernateFonteDeDados(ConsultaSql consulta)
        {
            _consulta = consulta;
        }

        public object GetDados(String sql)
        {
            return _consulta.UniqueResult(sql);
        }
    }
}
