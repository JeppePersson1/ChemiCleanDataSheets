using ChemiCleanDataSheets.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiCleanDataSheets.Web.Repositories
{
    public class DataSheetRepository
    {
        private readonly DataContext _context;

        public DataSheetRepository()
        {
            _context = new DataContext();
        }

        public StoredDataSheet Create(StoredDataSheet storedDataSheet)
        {
            _context.StoredDataSheets.Add(storedDataSheet);
            _context.SaveChanges();

            return storedDataSheet;
        }

        public StoredDataSheet Update(StoredDataSheet newDetails)
        {
            var storedDataSheet = Read(newDetails.Url);

            var entity = _context.StoredDataSheets.Find(storedDataSheet.Id);
            if (entity != null)
            {
                _context.Entry(entity).CurrentValues.SetValues(newDetails);
            }
            _context.SaveChanges();

            return storedDataSheet;
        }

        public StoredDataSheet Read(string url)
        {
            var storedDataSheet = _context.StoredDataSheets.FirstOrDefault(x => x.Url == url);

            return storedDataSheet;
        }
    }
}
