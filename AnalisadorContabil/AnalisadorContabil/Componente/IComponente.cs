using System;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Componente
{
    public interface IComponente
    {
        String Id();
        
        IValor GetValor();
        
        IComponente AdicionaFonte(IFonteDeDados fonte);
    }
}