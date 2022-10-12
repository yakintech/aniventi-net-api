using Aniventi.Api.Models.Exceptions;
using Aniventi.Api.Models.Filters;
using Aniventi.BLL.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aniventi.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
  
    public class ProductController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;


        public ProductController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [SampleActionFilter]
        [ResponseHeaderFilter("tokenExpire","04:03")]
        public IActionResult GetProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAllWithQueryable()
                .Include(q => q.Category).ToList();
         

            var data = products.Where(q => q.UnitsInStock > 20).ToList();

            return Ok(products);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);

            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                throw new DataNotFoundException(id.ToString());
                //return NotFound();
            }
        }


    }




}
