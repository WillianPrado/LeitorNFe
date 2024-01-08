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
        public string ID { get; set; }
        public string nNF { get; set; }
        public string chNFe { get; set; }
        public string dhEmi { get; set; }
        public Emitent Emitent { get; set; }
        public Destinatario Dest { get; set; }
        public ICMSTot ICMSTot { get; set; }
        public InfProt InfProt { get; set; }
        public List<Product> Products { get; set; }
        private XNamespace infNFe { get; set; }
        private XDocument XMLDoc { get; set; }

        public InfNFe(string XMLContent)
        {
            XMLDoc = XDocument.Parse(XMLContent);

            infNFe = "http://www.portalfiscal.inf.br/nfe";
            ID = XMLDoc.Descendants(infNFe + "infNFe").FirstOrDefault()?.Attribute("Id")?.Value;
        }
        public InfNFe ParseProd()
        {
            try
            {
                var prodElements = XMLDoc.Descendants(infNFe + "prod").ToList();

                if (prodElements == null || prodElements.Count == 0)
                    Products = new List<Product>();

                Products = prodElements.Select(prod =>
                {
                    return new Product
                    {
                        cProd = prod.Element(infNFe + "cProd")?.Value,
                        cEAN = prod.Element(infNFe + "cEAN")?.Value,
                        xProd = prod.Element(infNFe + "xProd")?.Value,
                        NCM = prod.Element(infNFe + "NCM")?.Value,
                        CEST = prod.Element(infNFe + "CEST")?.Value,
                        CFOP = prod.Element(infNFe + "CFOP")?.Value,
                        uCom = prod.Element(infNFe + "uCom")?.Value,
                        qCom = Convert.ToDecimal(prod.Element(infNFe + "qCom")?.Value),
                        vUnCom = Convert.ToDecimal(prod.Element(infNFe + "vUnCom")?.Value),
                        vProd = Convert.ToDecimal(prod.Element(infNFe + "vProd")?.Value),
                        cEANTrib = prod.Element(infNFe + "cEANTrib")?.Value,
                        uTrib = prod.Element(infNFe + "uTrib")?.Value,
                        qTrib = Convert.ToDecimal(prod.Element(infNFe + "qTrib")?.Value),
                        vUnTrib = Convert.ToDecimal(prod.Element(infNFe + "vUnTrib")?.Value),
                        vDesc = Convert.ToDecimal(prod.Element(infNFe + "vDesc")?.Value),
                        indTot = Convert.ToInt32(prod.Element(infNFe + "indTot")?.Value),
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
                var emitElement = XMLDoc.Descendants(infNFe + "emit").FirstOrDefault();

                if (emitElement == null)
                    return this;

                Emitent = new Emitent()
                {
                    CNPJ = emitElement.Element(infNFe + "CNPJ")?.Value,
                    xNome = emitElement.Element(infNFe + "xNome")?.Value,
                    xFant = emitElement.Element(infNFe + "xFant")?.Value,
                    EmitentAddress = new Address()
                    {
                        xLgr = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "xLgr")?.Value,
                        nro = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "nro")?.Value,
                        xBairro = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "xBairro")?.Value,
                        cMun = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "cMun")?.Value,
                        xMun = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "xMun")?.Value,
                        UF = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "UF")?.Value,
                        CEP = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "CEP")?.Value,
                        cPais = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "cPais")?.Value,
                        xPais = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "xPais")?.Value,
                        fone = emitElement.Element(infNFe + "enderEmit")?.Element(infNFe + "fone")?.Value
                    }
                };

                return this;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public InfNFe ParseDest()
        {
            try
            {
                var destElement = XMLDoc.Descendants(infNFe + "dest").FirstOrDefault();

                if (destElement == null)
                    return this;

                Dest = new Destinatario
                {
                    CPF = destElement.Element(infNFe + "CPF")?.Value,
                    xNome = destElement.Element(infNFe + "xNome")?.Value,
                    IE = destElement.Element(infNFe + "IE")?.Value,
                    email = destElement.Element(infNFe + "email")?.Value,
                    DestAddress = new Address
                    {
                        xLgr = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "xLgr")?.Value,
                        nro = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "nro")?.Value,
                        xBairro = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "xBairro")?.Value,
                        cMun = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "cMun")?.Value,
                        xMun = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "xMun")?.Value,
                        UF = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "UF")?.Value,
                        CEP = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "CEP")?.Value,
                        cPais = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "cPais")?.Value,
                        xPais = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "xPais")?.Value,
                        fone = destElement.Element(infNFe + "enderDest")?.Element(infNFe + "fone")?.Value
                    }
                };

                return this;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public InfNFe ParseInfProt()
        {
            try
            {
                XNamespace ns = "http://www.portalfiscal.inf.br/nfe";
                var infProtElement = XMLDoc.Descendants(ns + "infProt").FirstOrDefault();

                if (infProtElement != null)
                {
                    InfProt = new InfProt
                    {
                        chNFe = (string)infProtElement.Element(ns + "chNFe")
                    };
                }
                return this;
            }
            catch (Exception ex)
            {
                return this;
            }
        }

        public InfNFe ParseICMSTot()
        {
            try
            {
                XNamespace ns = "http://www.portalfiscal.inf.br/nfe";
                var ICMSTotElement = XMLDoc.Descendants(ns + "ICMSTot").FirstOrDefault();

                if (ICMSTotElement != null)
                {
                    ICMSTot = new ICMSTot
                    {
                        vNF = Convert.ToDecimal(ICMSTotElement.Element(ns + "vNF")?.Value ?? "0"),
                    };
                }
                return this;
            }
            catch (Exception ex)
            {
                return this;
            }
        }
    }
}
