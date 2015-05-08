using AnalisadorContabil.Valor;
using System;

namespace AnalisadorContabil.Componente
{
    public interface IComponente
    {
        String Id();
        
        IValor GetValor();
    }
}