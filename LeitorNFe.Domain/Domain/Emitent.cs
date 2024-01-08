using System;
using System.Collections.Generic;
using System.Text;

namespace LeitorNFe.Domain.Domain
{
    public class Emitent
    {
        // Propriedades da tabela Emitents
        public int ID { get; set; } // Chave Primária
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public int infNFeID { get; set; }
        public int AddressID { get; set; } 
        public Address Address { get; set; }
    }
}
