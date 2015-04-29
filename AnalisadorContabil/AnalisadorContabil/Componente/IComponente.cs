using System;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Componente
{
    public interface IComponente
    {
        String Id();

        IValor GetValor();
    }
}