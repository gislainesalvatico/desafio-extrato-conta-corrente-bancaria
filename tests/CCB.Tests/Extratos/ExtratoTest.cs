using CCB.Web.Models;
using NUnit.Framework;

namespace CCB.Tests
{
    [TestFixture]
    public class ExtratoTest
    {
        [Test]
        public void Saldo_Suficiente_Para_Retirada_Pagamento()
        {
            var extrato = new Extrato();
            var resultado = extrato.SaldoInsuficiente(10, 5);

            Assert.False(resultado);
        }

        [Test]
        public void Saldo_Insuficiente_Para_Retirada_Pagamento()
        {
            var extrato = new Extrato();
            var resultado = extrato.SaldoInsuficiente(10, 15);

            Assert.True(resultado);
        }
    }
}
