using LeitorNFe.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorNFe.Domain.Interfaces
{
    public interface IInfNFeRepository
    {
        InfNFe Save(InfNFe infNFe);
        InfNFe GetById(string id);
    }
}
