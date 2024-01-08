using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeitorNFe.Domain.Domain
{
    public class InfNFe
    {
        public int ID { get; set; }
        public string nNF { get; set; }
        public string chNFe { get; set; }
        public string dhEmi { get; set; }
        public long vNF { get; set; }
        public Emitent Emitent { get; set; }
        public Recipient Recipient { get; set; }
        public ICMSTot ICMSTot { get; set; }
        public List<Product> Products { get; set; }
        private string XMLContent { get; set; }

        public InfNFe(string XMLContent)
        {
            this.XMLContent = XMLContent;
        }
        public InfNFe ParseProd()
        {
            try
            {

                XDocument xmlDoc = XDocument.Parse(XMLContent);

                XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

                var detElements = xmlDoc.Descendants(ns + "prod").ToList();

                if (detElements == null || detElements.Count == 0)
                    Products = new List<Product>();

                Products = detElements.Select(det =>
                {
                    return new Product
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
                return this;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public InfNFe ParseEmitente()
        {
            try
            {
                XDocument xmlDoc = XDocument.Parse(XMLContent);
                XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

                var emitElement = xmlDoc.Descendants(ns + "emit").FirstOrDefault();

                if (emitElement == null)
                    return this;

                Emitent = new Emitent()
                {
                    CNPJ = emitElement.Element(ns + "CNPJ")?.Value,
                    xNome = emitElement.Element(ns + "xNome")?.Value,
                    xFant = emitElement.Element(ns + "xFant")?.Value,
                    EmitentAddress = new Address()
                    {
                        xLgr = emitElement.Element(ns + "enderEmit")?.Element(ns + "xLgr")?.Value,
                        nro = emitElement.Element(ns + "enderEmit")?.Element(ns + "nro")?.Value,
                        xBairro = emitElement.Element(ns + "enderEmit")?.Element(ns + "xBairro")?.Value,
                        cMun = emitElement.Element(ns + "enderEmit")?.Element(ns + "cMun")?.Value,
                        xMun = emitElement.Element(ns + "enderEmit")?.Element(ns + "xMun")?.Value,
                        UF = emitElement.Element(ns + "enderEmit")?.Element(ns + "UF")?.Value,
                        CEP = emitElement.Element(ns + "enderEmit")?.Element(ns + "CEP")?.Value,
                        cPais = emitElement.Element(ns + "enderEmit")?.Element(ns + "cPais")?.Value,
                        xPais = emitElement.Element(ns + "enderEmit")?.Element(ns + "xPais")?.Value,
                        fone = emitElement.Element(ns + "enderEmit")?.Element(ns + "fone")?.Value
                    }
                };

                return this;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
