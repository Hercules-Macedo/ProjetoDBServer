using ProjetoDBServer.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDBServer.API.Command
{
    public class TransferenciaCommand
    {
        public ContaCorrenteViewModel ContaOrigem { get; set; }
        public ContaCorrenteViewModel ContaDestino { get; set; }
        public double Valor { get; set; }
    }
}
