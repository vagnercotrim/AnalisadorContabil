using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalisadorContabil
{
    public class Tabela
    {
        public String Codigo { get; set; }
        public String Descricao { get; set; }
        public String Parametros { get; set; }
        public String Tipo { get; set; }

        public Tabela(String codigo, String descricao, String tipo, String parametros)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tipo = tipo;
            Parametros = parametros;
        }

        public object Get(String key)
        {
            try
            {
                object value = ParametrosToList(Parametros).First(p => p.Nome.Equals(key)).Valor;

                return value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList<Parametro> ParametrosToList()
        {
            return ParametrosToList(Parametros);
        }

        private IList<Parametro> ParametrosToList(String parametros)
        {
            IList<String> strings = parametros.Split(';').ToList();

            return strings.Select(ToParametro).ToList();
        }

        private Parametro ToParametro(String value)
        {
            String[] values = value.Split(':');

            return new Parametro(values[0], values[1]);
        }

    }
}
