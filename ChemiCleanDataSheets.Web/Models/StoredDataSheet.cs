using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiCleanDataSheets.Web.Models
{
    public class StoredDataSheet
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public byte[] StoredFile { get; set; }
    }
}
