using System.Linq;
using AnalisadorContabil.Validador.Regras;
using NUnit.Framework;

namespace AnalisadorContabil.Validador.Testes
{
    [TestFixture]
    public class MaiorQueTest
    {

        [Test]
        public void Verifica_se_o_valor_75_e_maior_que_100_e_retornar_um_alerta()
        {
            IRegraValidacao regra = new MaiorQue(75, 100);

            regra.Validar();

            Assert.IsTrue(regra.Notificacoes().Where(n => n.Tipo == Tipo.Alerta).ToList().Count == 1);
        }

    }
}
