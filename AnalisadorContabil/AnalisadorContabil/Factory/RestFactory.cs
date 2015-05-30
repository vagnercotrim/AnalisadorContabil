﻿using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.FonteDeDados;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Factory
{
    public class RestFactory
    {
        public static Rest Cria(Tabela tabela, IDictionary<string, object> variaveisSistema, IFonteDeDados fonte)
        {
            String recurso = tabela.Get("recurso").ToString();

            return new Rest(tabela.Codigo, recurso, tabela.Retorno, variaveisSistema, fonte);
        }
    }
}