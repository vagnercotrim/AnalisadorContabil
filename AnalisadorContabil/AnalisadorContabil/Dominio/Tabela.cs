﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalisadorContabil.Dominio
{
    public class Tabela
    {
        public String Codigo { get; set; }
        public String Descricao { get; set; }
        public String Parametros { get; set; }
        public String Tipo { get; set; }
        public String Fonte { get; set; }
        public String Retorno { get; set; }

        public Tabela(String codigo, String descricao, String tipo, String fonte, String retorno, Parametro parametros)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tipo = tipo;
            Fonte = fonte;
            Retorno = retorno;
            Parametros = JsonConvert.SerializeObject(new List<Parametro> { parametros });
        }

        public Tabela(String codigo, String descricao, String tipo, String fonte, String retorno, IList<Parametro> parametros)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tipo = tipo;
            Fonte = fonte;
            Retorno = retorno;
            Parametros = JsonConvert.SerializeObject(parametros);
        }

        public Tabela(String codigo, String descricao, String tipo, String fonte, String retorno, String parametros)
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
