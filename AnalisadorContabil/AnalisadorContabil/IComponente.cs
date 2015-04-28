using System;

namespace AnalisadorContabil
{
    public interface IComponente
    {
        String Id();

        object GetValor();
    }
}