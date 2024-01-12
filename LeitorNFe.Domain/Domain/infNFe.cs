using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeitorNFe.Domain.Domain
{
    public class InfNFe
    {
        public InfNFe() { }
        public int ID { get; set; }
        public string IDNFe { get; set; }
        public string EmitID { get; set; }
        public string DestID { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public Ide Ide { get; set; }
        public Emit Emit { get; set; }
        public Dest Dest { get; set; }
        public ICMSTot ICMSTot { get; set; }
        public InfProt InfProt { get; set; }
        public List<Prod> Products { get; set; }
        private XNamespace infNFe { get; set; }
        private XDocument XMLDoc { get; set; }

        /// <summary>
        /// Retorna uma InfNFe com os dados extraidos de um arquivo XML
        /// </summary>
        /// <param name="memoryStream"></param>
        public InfNFe(MemoryStream memoryStream)
        {
            try
            {
                using (var reader = new StreamReader(memoryStream))
                {
                    string xmlContent = reader.ReadToEndAsync().Result;
                    XMLDoc = XDocument.Parse(xmlContent);

                    infNFe = "http://www.portalfiscal.inf.br/nfe";
                    IDNFe = XMLDoc.Descendants(infNFe + "infNFe").FirstOrDefault()?.Attribute("Id")?.Value;
                         ParseEmitente()
                        .ParseIde()
                        .ParseDest()
                        .ParseProd()
                        .ParseInfProt()
                        .ParseICMSTot();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cria infNFe");
            }
        }

        public InfNFe ParseIde()
        {
            try
            {
                var ideElements = XMLDoc.Descendants(infNFe + "ide").FirstOrDefault();

                if (ideElements == null)
                {
                    Ide = new Ide();
                    return this;
                }
                    
                Ide = new Ide
                {
                    nNF = long.TryParse(ideElements.Element(infNFe + "nNF").Value?
                            .Replace(".", ","), out var parsednNF) ? parsednNF : 0,
                    dhEmi = DateTime.TryParseExact(ideElements.Element(infNFe + "dhEmi")?.Value, 
                            "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parseddhEmi) ? parseddhEmi : DateTime.MinValue,
                    dhSaiEnt = DateTime.TryParseExact(ideElements.Element(infNFe + "dhEmi")?.Value,
                            "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parseddhSaiEnt) ? parseddhEmi : DateTime.MinValue
                };
            }
            catch (Exception ex) 
            {
            }
            return this;
        }
        public InfNFe ParseProd()
        {
            try
            {
                var prodElements = XMLDoc.Descendants(infNFe + "prod").ToList();

                if (prodElements == null || prodElements.Count == 0)
                {
                    Products = new List<Prod>();
                    return this;
                }
                    

                Products = prodElements.Select(prod =>
                {
                    return new Prod
                    {
                        cProd = prod.Element(infNFe + "cProd")?.Value,
                        cEAN = prod.Element(infNFe + "cEAN")?.Value,
                        xProd = prod.Element(infNFe + "xProd")?.Value,
                        NCM = prod.Element(infNFe + "NCM")?.Value,
                        CEST = prod.Element(infNFe + "CEST")?.Value,
                        CFOP = prod.Element(infNFe + "CFOP")?.Value,
                        uCom = prod.Element(infNFe + "uCom")?.Value,
                        qCom = Convert.ToDecimal(prod.Element(infNFe + "qCom")?.Value),
                        vUnCom = decimal.TryParse(prod.Element(infNFe + "vUnCom").Value?
                            .Replace(".", ","), out var parsedVUnCom) ? parsedVUnCom : 0,
                        vProd = Convert.ToDecimal(prod.Element(infNFe + "vProd")?.Value),
                        cEANTrib = prod.Element(infNFe + "cEANTrib")?.Value,
                        uTrib = prod.Element(infNFe + "uTrib")?.Value,
                        qTrib = Convert.ToDecimal(prod.Element(infNFe + "qTrib")?.Value),
                        vUnTrib = decimal.TryParse(prod.Element(infNFe + "vUnTrib").Value?
                            .Replace(".", ","), out var parsedVvUnTrib) ? parsedVUnCom : 0,
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

                Emit = new Emit()
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
                Emit.AddressID = Emit.EmitentAddress.GeneranteID();
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

                Dest = new Dest
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
                Dest.AddressID =  Dest.DestAddress.GeneranteID();
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
                        vNF = decimal.TryParse(ICMSTotElement.Element(infNFe + "vNF").Value?.Replace(".", ","), out var parsedVUnCom) ? parsedVUnCom : 0,
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
