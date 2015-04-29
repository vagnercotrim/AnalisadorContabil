using System;

namespace AnalisadorContabil.Componente
{
    public interface IComponente
    {
        String Id();

        object GetValor();
    }
}