using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChemiCleanDataSheets.Web.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ChemiCleanDataSheets.Web.Helpers;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ChemiCleanDataSheets.Web.Repositories;

namespace ChemiCleanDataSheets.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(new Uri(@"https://localhost:44331/api/product/getproducts"));
            var jsonfile = result.Content.ReadAsStringAsync().Result;
            var jsonlist = JsonConvert.DeserializeObject<TblProduct[]>(jsonfile);
            List<TblProduct> model = jsonlist.ToList();
            return View(model);
        }

        [HttpGet]
        public FileResult GetPDF(string url)
        {
            var dataSheetRepository = new DataSheetRepository();
            var dataSheet = dataSheetRepository.Read(url);
            try
            {
                var pdfHelper = new PDFHelper();
                var data = pdfHelper.GetBytesFromURL(url);
                if(dataSheet == null)
                {
                    var newDataSheet = new StoredDataSheet()
                    {
                        Url = url,
                        StoredFile = data
                    };
                    dataSheetRepository.Create(newDataSheet);
                }
                else if(dataSheet.StoredFile != data)
                {
                    var newDataSheet = new StoredDataSheet()
                    {
                        StoredFile = data
                    };
                    dataSheetRepository.Update(newDataSheet);
                }

                return File(data, "application/pdf");
            }
            catch
            {
                if (dataSheet == null)
                {
                    RedirectToAction("Error");
                }
                return File(dataSheet.StoredFile, "application/pdf");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
