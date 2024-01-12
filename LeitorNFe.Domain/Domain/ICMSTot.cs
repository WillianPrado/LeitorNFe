using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorNFe.Domain.Domain
{
    public class ICMSTot
    {
        public int ID { get; set; }
        public int infNFeID { get; set; }
        [Column(TypeName = "decimal(18, 10)")]
        public decimal vNF {  get; set; }
    }
}
