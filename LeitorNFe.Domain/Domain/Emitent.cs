using System;
using System.Collections.Generic;
using System.Text;

namespace LeitorNFe.Domain.Domain
{
    public class Emitent
    {
        // Propriedades da tabela Emitents
        public string ID { get; set; } // Chave Primária
        public string xNome { get; set; }
        public string xFant { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public int infNFeID { get; set; }
        public string AddressID { get; set; } 
        public Address EmitentAddress { get; set; }
    }
}
