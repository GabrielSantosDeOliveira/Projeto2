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
            Transacoes = new List<Transacao>();
        }
        public string numero;
        public double saldo;
        public double limite;
        public bool status;
        public List<Transacao>
            Transacoes;
        public bool Saque(double valor)
        {
            if (saldo - valor > -limite)
            {
                saldo -= valor;
                Transacoes.Add(new Transacao(valor, 'S', this));
                return true;
            }
            return false;
        }
        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Transacoes.Add(new Transacao(valor, 'D', this));
                return true;
            }
            return false;
        }

        public bool Transferir(CCorrente destino, double valor)
        {
            if (destino.status && Saque(valor) && destino.Depositar(valor))
            {
                Transacoes[Transacoes.Count - 1].duplicata = destino.Transacoes[Transacoes.Count - 1];
                destino.Transacoes[destino.Transacoes.Count - 1].duplicata = Transacoes[Transacoes.Count - 1];
                return true;
            }
            return false;
        }
        public bool Transferir(CPoupanca destino, double valor)
        {
            if (destino.status && Saque(valor) && destino.Depositar(valor))
            {
                Transacoes[Transacoes.Count - 1].duplicata = destino.Transacoes[Transacoes.Count - 1];
                destino.Transacoes[destino.Transacoes.Count - 1].duplicata = Transacoes[Transacoes.Count - 1];
                return true;
            }
            return false;
        }
    }
}
