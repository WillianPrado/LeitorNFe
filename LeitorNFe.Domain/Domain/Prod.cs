using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LeitorNFe.Domain.Domain
{
    public class Prod
    {
        public int ID { get; set; } // Chave Primária
        public string cProd { get; set; }
        public string cEAN { get; set; }
        public string xProd { get; set; }
        public string NCM { get; set; }
        public string CEST { get; set; }
        public string CFOP { get; set; }
        public string uCom { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        public decimal qCom { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        public decimal vUnCom { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        public decimal vProd { get; set; }

        public string cEANTrib { get; set; }
        public string uTrib { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        public decimal qTrib { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        public decimal vUnTrib { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        public decimal vDesc { get; set; }

        public int indTot { get; set; }
        /// <summary>
        /// Chave estrangeira da nota fiscal
        /// </summary>
        public string infNFeID { get; set; }
        
    }
}
