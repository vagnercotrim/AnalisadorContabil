using System.Collections.Generic;

namespace AnalisadorContabil.Validador
{
    public interface IRegraValidacao
    {
        IList<Notificacao> Validar();
    }
}
