using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChemiCleanDataSheets.Web.Helpers
{
    public class PDFHelper
    {
        public byte[] GetBytesFromURL(string url)
        {
            using (var client = new WebClient())
            {
                byte[] data = client.DownloadData(url);
                return data;
            }
        }
    }
}
