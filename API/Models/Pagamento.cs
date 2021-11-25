using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Pagamento
    {
        public Pagamento() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string NomePagamento { get; set; }
        public string Parcelamento{get; set; }
        public DateTime CriadoEm { get; set; }

    }
}