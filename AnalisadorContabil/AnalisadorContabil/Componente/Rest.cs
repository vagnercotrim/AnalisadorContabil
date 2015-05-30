﻿using System.Collections.Generic;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using System;

namespace AnalisadorContabil.Componente
{
    public class Rest : IComponente
    {
        private readonly String _id;
        private readonly string _recurso;
        private readonly string _retorno;
        private readonly IFonteDeDados _fonteDeDados;

        public Rest(String id, String recurso, String retorno, IDictionary<string, object> variaveisSistema, IFonteDeDados fonteDeDados)
        {
            _id = id;
            _recurso = VariaveisSistema.AtribuiValorVariaveis(recurso, variaveisSistema);
            _retorno = retorno;
            _fonteDeDados = fonteDeDados;
        }

        public string Id()
        {
            return _id;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Consulta(), _retorno);
        }

        private object Consulta()
        {
            return _fonteDeDados.GetDados(_recurso);
        }
    }
}
