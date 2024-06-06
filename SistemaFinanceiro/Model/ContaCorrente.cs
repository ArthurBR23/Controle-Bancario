using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class ContaCorrente
    {
       
        public Conta conta;
        public class ContaCaixinha : Conta
        {
            public ContaCaixinha(long numero, decimal saldo, Cliente titular)
                : base(numero, saldo, titular)
            {
                if (saldo < 10)
                {
                    throw new ArgumentException("O saldo inicial deve ser superior a R$10,00");
                }
            }
            public override void Deposito(decimal valor)
            {
                if (valor < 1)
                {
                    throw new ArgumentException("Depósitos devem ser superiores a R$1,00");
                }

                base.Deposito(valor);
                _saldo += 1;
            }


            public override decimal Saque(decimal valor)
            {
                decimal saqueValor = valor + 5;
                if (Saldo >= saqueValor)
                {
                    _saldo -= 5;
                    return base.Saque(valor);
                }
                else
                {
                    throw new ArgumentException("Valor do saque ultrapassa o saldo");
                }
            }
        }
    }
}
