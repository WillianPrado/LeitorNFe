using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeitorNFe.Domain.Domain
{
    public class Dest
    {
        [Key]
        public string CPF { get; set; }
        public string xNome { get; set; }
        public string IE { get; set; }
        public string email { get; set; }
        public Address DestAddress { get; set; }
        public string AddressID { get; set; }
        //public string infNFeID { get; set; }
    }
}
