using Projeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{
    public class CPoupanca:Conta
    {
        public CPoupanca() : base()
        {
            this.limite = 0;
        }
        public CPoupanca(string numero) : base(numero)
        {
            this.limite = 0;
        }
 
    }
}
