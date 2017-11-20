using System;
using System.Collections.Generic;
using System.Linq;
using SportUnite.DAL;
using SportUnite.Domain.Models;

namespace SportUnite.BLL
{
    public class InvoiceManager : IManager<Invoice>
    {
        private IInvoiceRepository invoiceRepository;

        public InvoiceManager(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public bool Delete(Invoice invoice)
        {
            invoiceRepository.DeleteInvoice(invoice);
            return invoiceRepository.Save();
        }

        public Invoice Get(int invoiceId)
        {
            return invoiceRepository.Invoices.Where(i => i.InvoiceId == invoiceId).FirstOrDefault();
        }

        public IEnumerable<Invoice> Get()
        {
            return invoiceRepository.Invoices;
        }

        public bool Save(Invoice invoice)
        {
            invoiceRepository.SaveInvoice(invoice);
            return invoiceRepository.Save();
        }
    }
}