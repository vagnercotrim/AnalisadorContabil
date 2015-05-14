using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorContabil.Testes.Integracao.Models
{
    public class Conta
    {
        public virtual int Id { get; set; }
        public virtual String Numero { get; set; }
        public virtual decimal ValorReceita { get; set; }
        public virtual decimal ValorDespesa { get; set; }
        public virtual int Empresa { get; set; }
        public virtual int Ano { get; set; }
        public virtual int Periodo { get; set; }
    }
}
