
using Stock.DBAL.Context;
using Stock.DBAL.Models;

namespace Stock.DBAL.Repositories.Invoices_Repo;

public class InvoicesRepo : GenericRepo<Invoice> , IInvoicesRepo
{
    #region Fields
    private readonly StockDbContext _context;
    #endregion

    #region Ctor
    public InvoicesRepo(StockDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Methods

    #endregion
}
