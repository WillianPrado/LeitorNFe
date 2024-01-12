using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorNFe.Domain.Domain
{
    public class Ide
    {
        public int ID { get; set; }
        public long nNF { get; set; }
        public DateTime dhEmi { get; set; }
        public DateTime dhSaiEnt { get; set; }
        public int InfNFeID { get; set; }
    }
}
