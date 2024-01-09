using System;
using System.Collections.Generic;
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
        public decimal qCom { get; set; } 
        public decimal vUnCom { get; set; } 
        public decimal vProd { get; set; } 
        public string cEANTrib { get; set; } 
        public string uTrib { get; set; } 
        public decimal qTrib { get; set; } 
        public decimal vUnTrib { get; set; } 
        public decimal vDesc { get; set; } 
        public int indTot { get; set; }
        /// <summary>
        /// Chave estrangeira da nota fiscal
        /// </summary>
        public string infNFeID { get; set; }
        public List<Prod> ParseProd(string xmlContent)
        {
            try
            {

                XDocument xmlDoc = XDocument.Parse(xmlContent);

                XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

                var detElements = xmlDoc.Descendants(ns + "prod").ToList();

                if( detElements == null || detElements.Count == 0 )
                    return new List<Prod>();

                List<Prod> products = detElements.Select(det =>
                {
                    return new Prod
                    {
                        cProd = det.Element(ns + "cProd")?.Value,
                        cEAN = det.Element(ns + "cEAN")?.Value,
                        xProd = det.Element(ns + "xProd")?.Value,
                        NCM = det.Element(ns + "NCM")?.Value,
                        CEST = det.Element(ns + "CEST")?.Value,
                        CFOP = det.Element(ns + "CFOP")?.Value,
                        uCom = det.Element(ns + "uCom")?.Value,
                        qCom = Convert.ToDecimal(det.Element(ns + "qCom")?.Value),
                        vUnCom = Convert.ToDecimal(det.Element(ns + "vUnCom")?.Value),
                        vProd = Convert.ToDecimal(det.Element(ns + "vProd")?.Value),
                        cEANTrib = det.Element(ns + "cEANTrib")?.Value,
                        uTrib = det.Element(ns + "uTrib")?.Value,
                        qTrib = Convert.ToDecimal(det.Element(ns + "qTrib")?.Value),
                        vUnTrib = Convert.ToDecimal(det.Element(ns + "vUnTrib")?.Value),
                        vDesc = Convert.ToDecimal(det.Element(ns + "vDesc")?.Value),
                        indTot = Convert.ToInt32(det.Element(ns + "indTot")?.Value),
                    };
                }).ToList();

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        
    }
}
