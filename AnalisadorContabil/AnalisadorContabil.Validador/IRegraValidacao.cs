using System.Collections.Generic;

namespace AnalisadorContabil.Validador
{
    public interface IRegraValidacao
    {
        void Validar();

        IList<Notificacao> Notificacoes();
    }
}
