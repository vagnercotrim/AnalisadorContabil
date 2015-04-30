using System;

namespace AnalisadorContabil.FonteDeDados
{
    public interface IFonteDeDados
    {
        Tabela GetDados(String id);
    }
}