using ProjetoDBServer.Domain.Entities;
using System;
using Xunit;

namespace ProjetoDBServer.Test
{
    public class TesteTransferencia
    {
        [Theory]
        [InlineData(500,500)]
        [InlineData(500, 1500)]
        [InlineData(0, 10)]
        [InlineData(500, 0)]
        public void TesteDeTransferenciaEntreContas(double saldo, double valor)
        {
            ContaCorrente CcOrigem = new ContaCorrente(1,"Fulano", saldo);
            ContaCorrente CcDestino = new ContaCorrente(1, "Ciclano", saldo);

            Assert.True(CcOrigem.Sacar(valor) && CcDestino.Depositar(valor));
        }
    }
}
