using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiCleanDataSheets.Web.Models
{
    public class TblProduct
    {
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] File { get; set; }
        public bool IsSavedLocally { get; set; }
    }
}
