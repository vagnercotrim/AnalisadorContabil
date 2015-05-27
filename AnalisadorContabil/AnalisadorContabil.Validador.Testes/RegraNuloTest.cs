using System;
using System.Collections.Generic;
using AnalisadorContabil.Validador.Regras;
using NUnit.Framework;

namespace AnalisadorContabil.Validador.Testes
{
    [TestFixture]
    public class RegraNuloTest
    {
        [Test]
        [ExpectedException(typeof (Exception))]
        public void Verifica_se_a_regranulo_e_nao_retornar_nenhuma_notificacao()
        {
            IRegraValidacao regra = new RegraNulo();

            regra.Validar();
        }
    }
}
