using ProjetoDBServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDBServer.Domain.Interfaces
{
    public interface IContaCorrenteRepository
    {
        string Transferir(ContaCorrente origem, ContaCorrente destino, double valor);
    }
}
