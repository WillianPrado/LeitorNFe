using System;
using System.Collections.Generic;
using System.Text;

namespace LeitorNFe.Domain.Domain
{
    public class Invoice
    {
        // Propriedades da tabela Invoices
        public int ID { get; set; } // Chave Primária
        public string InvoiceNumber { get; set; }
        public string InvoicePath { get; set; }
        public string AccessKey { get; set; }
        public DateTime IssueDate { get; set; }
        public int EmitentID { get; set; } // Chave Estrangeira para a tabela Emitents
        public int RecipientID { get; set; } // Chave Estrangeira para a tabela Recipients
        public decimal TotalValue { get; set; }
    }
}