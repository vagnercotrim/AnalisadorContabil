using System;
using AnalisadorContabil.Validador.Regras;
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
            IList<IRegraValidacao> regras = new List<IRegraValidacao>
            {
                new MaiorQue(75, 100),
                new Igual(75, 100)
            };

            Validador validador = new Validador(regras);

            Resultado resultado = validador.Validar();

            Assert.IsTrue(resultado.Notificacoes.Count() == 2);
        }

        [Test]
        public void Deve_passar_uma_lista_com_2_regras_de_validacao_para_o_numero_50_e_nao_retornar_nenhuma_notificacao()
        {
            IList<IRegraValidacao> regras = new List<IRegraValidacao>
            {
                new MaiorQue(75, 70),
                new Igual(75, 75)
            };

            Validador validador = new Validador(regras);

            Resultado resultado = validador.Validar();

            Assert.IsTrue(resultado.EValido);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void Deve_passar_uma_lista_com_3_regras_e_gerar_uma_exception()
        {
            IList<IRegraValidacao> regras = new List<IRegraValidacao>
            {
                new MaiorQue(75, 100),
                new Igual(75, 100),
                new RegraNulo()
            };

            Validador validador = new Validador(regras);

            validador.Validar();
        }
    }
}
