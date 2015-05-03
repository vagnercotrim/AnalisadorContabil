using System;
using AnalisadorContabil.Dominio;

namespace AnalisadorContabil.FonteDeDados
{
    public interface IFonteDeDados
    {
        object GetDados(String id);
    }
}