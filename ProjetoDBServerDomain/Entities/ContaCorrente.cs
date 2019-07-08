using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDBServer.Domain.Entities
{
    public class ContaCorrente
    {
        public ContaCorrente(int numero, string nomeTitular, double saldo)
        {
            Numero = numero;
            NomeTitular = nomeTitular;
            Saldo = saldo;
        }

        public int Numero { get; private set; }
        public string NomeTitular { get; private set; }
        public double Saldo { get; private set; }

        /*como não havia no teste a instrução de diferenciar tipos de conta, 
        não criei uma classe conta para usar como abstraçao para essa conta corrente, 
        já que não teria outro filho (conta poupança por exemplo) */
        public bool Sacar (double valor)
        {
            if (this.Saldo >= valor)
            {
                this.Saldo -= valor;
                return true;
            }

            return false;
        }

        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                this.Saldo += valor;
                return true;
            }
            return false;
        }
    }
}
