using LeitorNFe.Domain.Domain;
using LeitorNFe.Domain.Interfaces;
using LeitorNFe.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorNFe.Infra.Repository
{
    public class InfNFeRepository : IInfNFeRepository
    {
        protected readonly LeitorNFeContext _leitorNFeContext;
        public InfNFeRepository(LeitorNFeContext leitorNFeContext) 
        { 
            _leitorNFeContext = leitorNFeContext;
        }

        public InfNFe Save(InfNFe infNFe)
        {
            if (InfNFeExists(infNFe.IDNFe))
                throw new Exception("Já existe uma InfNFe com o mesmo ID.");

            var infNFeSaved = SaveInfNFe(infNFe);
            return infNFeSaved;
        }
        private bool InfNFeExists(string id)
        {
            return _leitorNFeContext.InfNFe.Any(e => e.IDNFe == id && e.Active == true);
        }
        private InfNFe SaveInfNFe(InfNFe infNFe)
        {
            SaveOrUpdateEmitentAndAddress(infNFe);
            SaveOrUpdateDestAndAddress(infNFe);
            _leitorNFeContext.InfNFe.Add(infNFe);
            _leitorNFeContext.SaveChanges();
            var infNFeSaved = GetById(infNFe.ID);
            return infNFeSaved;
        }
        private InfNFe SaveOrUpdateEmitentAndAddress(InfNFe infNFe)
        {
            if (!AddressExists(infNFe.Emit.AddressID))
            {
                // Salva o endereço apenas se ele não existir no banco de dados
                var addressSaved = _leitorNFeContext.Addresses.Add(infNFe.Emit.EmitentAddress);
                _leitorNFeContext.SaveChanges();
                infNFe.Emit.EmitentAddress = addressSaved.Entity;
            }
            if (!EmitentExists(infNFe.Emit.CNPJ))
            {
                infNFe.Emit.AddressID = infNFe.Emit.EmitentAddress.ID;
                infNFe.Emit.EmitentAddress = null;
                var emitSaved = _leitorNFeContext.Emits.Add(infNFe.Emit);
                _leitorNFeContext.SaveChanges();
                infNFe.Emit = emitSaved.Entity;
            }
            infNFe.EmitID = infNFe.Emit.CNPJ;
            infNFe.Emit = null;
            return infNFe;
        }

        private InfNFe SaveOrUpdateDestAndAddress(InfNFe infNFe)
        {
            if (!AddressExists(infNFe.Dest.DestAddress.ID))
            {
                // Salva o endereço apenas se ele não existir no banco de dados
                var addressSaved = _leitorNFeContext.Addresses.Add(infNFe.Dest.DestAddress);
                _leitorNFeContext.SaveChanges();
                infNFe.Dest.DestAddress = addressSaved.Entity;
            }

            if (!DestExists(infNFe.Dest.CPF))
            {
                infNFe.Dest.AddressID = infNFe.Dest.DestAddress.ID;
                infNFe.Dest.DestAddress = null;
                var destSaved = _leitorNFeContext.Dests.Add(infNFe.Dest);
                _leitorNFeContext.SaveChanges();
                infNFe.Dest = destSaved.Entity;
                
            }
            infNFe.DestID = infNFe.Dest.CPF;
            infNFe.Dest = null;
            return infNFe;
        }

        private bool EmitentExists(string cnpj)
        {
            return _leitorNFeContext.Emits.Any(e => e.CNPJ == cnpj);
        }


        private bool DestExists(string cnpj)
        {
            return _leitorNFeContext.Dests.Any(e => e.CPF == cnpj);
        }
        private bool AddressExists(string addressId)
        {
            return _leitorNFeContext.Addresses.Any(a => a.ID == addressId);
        }
        public InfNFe GetById(int id)
        {
            try
            {
                var InfNFe = _leitorNFeContext.InfNFe
                    .Include(x => x.Emit)
                        .ThenInclude(x => x.EmitentAddress)
                    .Include(x => x.Dest)
                        .ThenInclude(x => x.DestAddress)
                    .Include(x => x.ICMSTot)
                    .Include(x => x.InfProt)
                    .Include(x => x.Products)
                    .FirstOrDefault(x => x.ID == id && x.Active == true);
                return InfNFe;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao caputurar InfNFe pelo ID");
            }
        }

        public (List<InfNFe> InfNFeList, int TotalCount) GetList(int page = 1, int pageSize = 10)
        {
            try
            {
                var totalCount = _leitorNFeContext.InfNFe.Count();

                var infNFeList = _leitorNFeContext.InfNFe.Where(x => x.Active == true)
                    .OrderBy(x => x.IDNFe )
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return (infNFeList, totalCount);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao capturar lista paginada de InfNFe");
            }
        }

        public string Delete(int id) 
        {
            try
            {
                var infNFe = _leitorNFeContext.InfNFe.FirstOrDefault(x => x.ID == id);
                if (infNFe != null)
                {
                    infNFe.Active = false;
                    _leitorNFeContext.SaveChanges();
                }
                else
                    throw new Exception("infNFe não encontrada");
            }catch (Exception ex)
            {
                throw new Exception("Erro ao deletar");
            }
            return "infNFe deletada com sucesso!";
        }
    }
}
