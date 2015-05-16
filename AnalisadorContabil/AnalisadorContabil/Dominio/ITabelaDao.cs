using System;

namespace AnalisadorContabil.Dominio
{
    public interface ITabelaDao
    {
        Tabela Get(String codigo);
    }
}