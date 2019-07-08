using ProjetoDBServer.Domain.Entities;
using ProjetoDBServer.Domain.Interfaces;

namespace ProjetoDBServer.Infra.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        public string Transferir(ContaCorrente origem, ContaCorrente destino, double valor)
        {
            //Como não estava especificado no teste, não fiz integraçao com banco de dados
            if (valor <= 0)
                return "Valor insuficiente!";

            if (origem.Sacar(valor) && destino.Depositar(valor))
                return "Transferência efetuada com sucesso!";

            return "Saldo insuficiente!";
        }
    }
}
