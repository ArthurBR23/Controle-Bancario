using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class ContaEspecial
    {
        private double _limite;
        public Conta _saque;
        public Conta _transferencia;

        public Conta conta;


        public class contaEspecial : Conta
        {
            public contaEspecial(long numero, decimal saldo, Cliente titular)
                : base(numero, saldo, titular)
            {
                if (saldo < 10)
                {
                    throw new ArgumentException("O saldo inicial deve ser superior a R$10,00");
                }
            }

            public override decimal Saque(decimal valor)
            {
                decimal saqueValor = valor + 5;
                if (valor > 200)
                {
                    throw new ArgumentException("Valor do saque não pode ultrapassar 200 reais");
                }
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

            public override void Transferencia(decimal valor, Conta contaDestino)
            {
                if (valor <= 0)
                {
                    throw new ArgumentException("A transferencia tem que ser maior que zero");
                }
                if (valor > 200)
                {
                    throw new ArgumentException("Valor da transferência não pode ultrapassar 200 reais");
                }
                if (Saldo < valor)
                {
                    throw new ArgumentException("Impossivel realizar a transferencia! O saldo ficará negativo");
                }

                _saldo -= valor;
                contaDestino._saldo += valor;
            }

        }
    }
}
