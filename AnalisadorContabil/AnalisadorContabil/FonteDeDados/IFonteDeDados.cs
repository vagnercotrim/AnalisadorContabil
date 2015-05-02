using System;
using AnalisadorContabil.Dominio;

namespace AnalisadorContabil.FonteDeDados
{
    public interface IFonteDeDados
    {
        Tabela GetDados(String id);
    }
}