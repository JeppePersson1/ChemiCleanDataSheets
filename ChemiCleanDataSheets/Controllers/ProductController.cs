using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemiCleanDataSheets.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChemiCleanDataSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var tblProducts = await productRepository.GetProducts();
                if (tblProducts == null)
                {
                    return NotFound();
                }

                return Ok(tblProducts);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}