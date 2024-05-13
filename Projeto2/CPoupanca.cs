using Projeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{
    public class CPoupanca
    {
        public string numero;
        public double saldo;
        public bool status;
        public List<Transacao>
            Transacoes;
        public CPoupanca()
        {
            this.saldo = 0;
            this.status = true;
            Transacoes = new List<Transacao>();
        }
        public CPoupanca(string numero)
        {
            this.numero = numero;
        }
        public bool Saque(double valor)
        {
            if (saldo - valor > 0)
            {
                saldo -= valor;
                Transacoes.Add(new Transacao(valor, 'S'));
                return true;
            }
            return false;
        }

        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Transacoes.Add(new Transacao(valor, 'D'));
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
