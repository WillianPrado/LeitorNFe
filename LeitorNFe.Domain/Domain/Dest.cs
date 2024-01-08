using System;
using System.Collections.Generic;
using System.Text;

namespace LeitorNFe.Domain.Domain
{
    public class Dest
    {
        public int ID { get; set; } // Chave Primária
        public string xNome { get; set; }
        public string CPF { get; set; }
        public string IE { get; set; }
        public string email { get; set; }
        public Address DestAddress { get; set; }
        public string AddressID { get; set; }
        public int infNFeID { get; set; }
    }
}
