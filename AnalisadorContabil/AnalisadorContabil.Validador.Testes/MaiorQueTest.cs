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

        [Test]
        public void Verifica_se_o_valor_120_e_maior_que_100_e_nao_retornar_nenhuma_notifacao()
        {
            IRegraValidacao regra = new MaiorQue(120, 100);

            regra.Validar();

            Assert.IsTrue(regra.Notificacoes().Count == 0);
        }

    }
}
