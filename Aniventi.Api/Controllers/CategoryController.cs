using Aniventi.BLL.Services.Repositories.General;
using Aniventi.BLL.Services.UnitOfWork;
using Aniventi.DAL.ORM.Entity.Category;
using Microsoft.AspNetCore.Mvc;

namespace Aniventi.Api.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;


        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();


          
            return null;
        }
    }
}
