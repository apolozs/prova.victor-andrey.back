using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Venda
    {
        public Venda() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string Cliente { get; set; }
        public List<ItemVenda> Itens { get; set; }
        public Pagamento Pagamento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}