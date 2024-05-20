using Projeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{
    public class Conta
    {
        public Conta(string numero, double limite) : this()
        {
            this.numero = numero;
            this.limite = limite;
        }
        public Conta()
        {
            this.saldo = 0;
            this.status = true;
            transacoes = new List<Transacao>();
        }
        protected string numero;
        protected double saldo;
        protected double limite;
        protected bool status;
        protected List<Transacao>
            transacoes;
        public string Numero
        {
            get => this.numero;
            set => this.numero = value;
        }
        public double Saldo
        {
            get => this.saldo;
        }
        public double Limite
        {
            get => this.limite;
            set
            {
                if(value >=0)
                {
                    this.limite = value;
                }
            }
        }
        public bool Status
        {
            get => this.status;
            set => this.status = value;
        }

        public List<Transacao> Transacoes
        {
            get => this.transacoes;
        }

        public bool Saque(double valor)
        {
            if (saldo - valor > -limite)
            {
                saldo -= valor;
                transacoes.Add(new Transacao(valor, 'S', this));
                return true;
            }
            return false;
        }
        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                transacoes.Add(new Transacao(valor, 'D', this));
                return true;
            }
            return false;
        }

        public bool Transferir(Conta destino, double valor)
        {
            if (destino.status && Saque(valor) && destino.Depositar(valor))
            {
                transacoes[transacoes.Count - 1].duplicata = destino.transacoes[transacoes.Count - 1];
                destino.transacoes[destino.transacoes.Count - 1].duplicata = transacoes[transacoes.Count - 1];
                return true;
            }
            return false;
        }
    }
}
