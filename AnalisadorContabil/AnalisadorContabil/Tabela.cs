using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AnalisadorContabil
{
    public class Tabela
    {
        private String Codigo { get; set; }
        private String Descricao { get; set; }
        private String Parametros { get; set; }
        private String Tipo { get; set; }

        public Tabela(String codigo, String descricao, String tipo, Parametro parametros)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tipo = tipo;
            Parametros = JsonConvert.SerializeObject(new List<Parametro>() { parametros });
        }

        public Tabela(String codigo, String descricao, String tipo, IList<Parametro> parametros)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tipo = tipo;
            Parametros = JsonConvert.SerializeObject(parametros);
        }

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
            return JsonConvert.DeserializeObject<List<Parametro>>(parametros);
        }
    }
}
