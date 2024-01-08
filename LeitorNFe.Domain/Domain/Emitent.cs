using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeitorNFe.Domain.Domain
{
    public class Emitent
    {
        // Propriedades da tabela Emitents
        [Key]
        public string CNPJ { get; set; }
        public string xNome { get; set; }
        public string xFant { get; set; }

        public string Email { get; set; }
        public int infNFeID { get; set; }
        public string AddressID { get; set; } 
        public Address EmitentAddress { get; set; }
    }
}
