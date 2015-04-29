using System;
using AnalisadorContabil.Componente;
using AnalisadorContabil.Valor;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    public class SqlTest
    {
        [Test]
        public void Deve_criar_um_componente_numerodecimal_com_valor_23()
        {
            IComponente componente = new Sql("C14-006", 23.00M);

            IValor valor = componente.GetValor();

            Assert.That(componente.Id(), Is.EqualTo("C14-006"));
            Assert.That(valor.Exibir(), Is.EqualTo("23,00"));
        }
    }
}
