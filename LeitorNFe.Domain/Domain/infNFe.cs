using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorNFe.Domain.Domain
{
    public class infNFe
    {
        public int ID { get; set; }
        public string nNF { get; set; }
        public string chNFe { get; set; }
        public string dhEmi { get; set; }
        public long vNF {  get; set; }
        public Emitent Emitent { get; set; }
        public Recipient Recipient { get; set; }    
        public List<Product> Products { get; set; }

    }
}
