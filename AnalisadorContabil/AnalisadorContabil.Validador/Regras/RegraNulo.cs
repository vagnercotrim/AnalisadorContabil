using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Validador.Regras
{
    public class RegraNulo : IRegraValidacao
    {
        public IList<Notificacao> Validar()
        {
            throw new Exception("Regra não encontrada.");
        }
    }
}
