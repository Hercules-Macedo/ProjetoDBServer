using ProjetoDBServer.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDBServer.Application.Interfaces
{
    public interface IContaCorrenteAppService
    {
        string Transferencia(ContaCorrenteViewModel origem, ContaCorrenteViewModel destino, double valor);
    }
}
