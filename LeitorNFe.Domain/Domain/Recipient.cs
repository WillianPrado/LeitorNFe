using System;
using System.Collections.Generic;
using System.Text;

namespace LeitorNFe.Domain.Domain
{
    public class Recipient
    {
        public int ID { get; set; } // Chave Primária
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string AddressID { get; set; }
        public int infNFeID { get; set; }
    }
}
