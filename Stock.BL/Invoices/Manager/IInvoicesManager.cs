using Stock.BL.Invoices.DTOs;

namespace Stock.BL.Invoices.Manager;

public interface IInvoicesManager
{
    Task<InvoiceReadDTO> Add(InvoiceAddDTO invoiceAddDto);
}
