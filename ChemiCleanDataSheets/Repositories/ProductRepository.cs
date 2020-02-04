using ChemiCleanDataSheets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiCleanDataSheets.Repositories
{
    public class ProductRepository : IProductRepository
    {
        masterContext db;
        public ProductRepository(masterContext _db)
        {
            db = _db;
        }

        public async Task<List<TblProduct>> GetProducts()
        {
            if (db != null)
            {
                return await db.TblProduct.ToListAsync();
            }

            return null;
        }
    }
}
