﻿using AnalisadorContabil.Validador.Regras;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace AnalisadorContabil.Validador.Testes
{
    [TestFixture]
    public class ValidadorTest
    {
        [Test]
        public void Deve_passar_uma_lista_com_2_regras_de_validacao_para_o_numero_50_e_o_limite_100_e_retornar_2_notificacoes()
        {
            IList<IRegraValidacao> regras = new List<IRegraValidacao>()
            {
                new MaiorQue(75, 100) ,
                new Igual(75, 100)
            };

            Validador validador = new Validador(regras);

            IEnumerable<Notificacao> notificacoes = validador.Validar();

            Assert.IsTrue(notificacoes.Count() == 2);
        }
    }
}
