using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalisadorContabil.Dominio
{
    public class Tabela
    {
        public String Codigo { get; set; }
        public String Descricao { get; set; }
        public IList<Parametro> Parametros { get; set; }
        public String Tipo { get; set; }
        public String Fonte { get; set; }
        public String Retorno { get; set; }

        public Tabela(String codigo, String descricao, String tipo, String fonte, String retorno, Parametro parametros)
            : this(codigo, descricao, tipo, fonte, retorno, new List<Parametro> { parametros }) { }

        public Tabela(String codigo, String descricao, String tipo, String fonte, String retorno, IList<Parametro> parametros)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tipo = tipo;
            Fonte = fonte;
            Retorno = retorno;
            Parametros = parametros;
        }

        public object Get(String key)
        {
            try
            {
                return Parametros.First(p => p.Nome.Equals(key)).Valor;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
