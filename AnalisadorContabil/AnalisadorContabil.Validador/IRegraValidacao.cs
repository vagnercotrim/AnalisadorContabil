using System.Collections.Generic;

namespace AnalisadorContabil.Validador
{
    public interface IRegraValidacao
    {
        IEnumerable<Notificacao> Validar();
    }
}
