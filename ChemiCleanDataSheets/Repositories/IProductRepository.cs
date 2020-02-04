using ChemiCleanDataSheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiCleanDataSheets.Repositories
{
    public interface IProductRepository
    {
        Task<List<TblProduct>> GetProducts();
    }
}
