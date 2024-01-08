using System;
using System.Collections.Generic;
using System.Text;

namespace LeitorNFe.Domain.Domain
{
    public class Address
    {
        public int ID { get; set; } // Chave Primária
        public string xLgr { get; set; }
        public string nro { get; set; }
        public string xCpl { get; set; }
        public string xBairro { get; set; }
        public string cMun { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string cPais { get; set; }
        public string xPais { get; set; }
        public string fone { get; set; }
    }
}
