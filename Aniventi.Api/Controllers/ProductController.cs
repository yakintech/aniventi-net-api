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
        public IActionResult GetProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAllWithQueryable()
                .Include(q => q.Category).ToList();
         


          

            var data = products.Where(q => q.UnitsInStock > 20).ToList();

            return Ok();
        }
    }




}
