using AnalisadorContabil.Validador.Regras;
using NUnit.Framework;
using System.Linq;

namespace AnalisadorContabil.Validador.Testes
{
    [TestFixture]
    public class ValidadorTest
    {
        [Test]
        public void Deve_passar_uma_lista_com_2_regras_de_validacao_para_o_numero_50_e_o_limite_100_e_retornar_2_notificacoes()
        {
            Validador validador = new Validador();
            validador.AdicionaRegra(new MaiorQue(75, 100));
            validador.AdicionaRegra(new Igual(75, 100));

            validador.Validar();

            Assert.IsTrue(validador.Notificacoes().ToList().Count == 2);
        }
    }
}
