using Aniventi.BLL.Services.Repositories.General;
using Aniventi.BLL.Services.UnitOfWork;
using Aniventi.DAL.ORM.Entity;
using Aniventi.Dto.Models.Category;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Aniventi.Api.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }


        [HttpGet]
        public IActionResult GetCategories()
        {
            string key = "categoryList";

            if (_memoryCache.TryGetValue(key, out object list))
                return Ok(list);


            var categories = _unitOfWork.CategoryRepository.GetAll();

            //List<CategoryListDto> model = categories.Select(x => new CategoryListDto()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    AddDate = x.AddDate,
            //    SortNumber = x.SortNumber
            //}).ToList();

            var model = _mapper.Map<List<CategoryListDto>>(categories);

            _memoryCache.Set(key, model, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(20),
                Priority = CacheItemPriority.Normal
            });

            return Ok(model);
        }


        [HttpGet]
        [Route("deletecache")]
        public IActionResult DeleteCache()
        {
            _memoryCache.Remove("categoryList");
            return Ok();
        }


        [HttpGet]
        [Route("single")]

        public IActionResult GetCategoryById(Guid id)
        {
  
            var category = _unitOfWork.CategoryRepository.GetById(id);

            SingleCategoryDto model = new SingleCategoryDto();
            model.Id = category.Id;
            model.Name = category.Name;
            model.Description = category.Description;
            model.AddDate = category.AddDate;

            return Ok(model);



        }


        [HttpPost]
        public IActionResult Add(CreateCategoryDto model)
        {
            Category category = new Category();

            category.Name = model.Name;
            category.Description = model.Description;

            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Commit();


            model.Id = category.Id;


            return Ok(model);

        }



        [HttpDelete]
        public IActionResult Delete(DeleteCategoryDto model)
        {
            _unitOfWork.CategoryRepository.Remove(model.Id);
            _unitOfWork.Commit();


            return Ok(model);
        }


        [HttpPut]
        public IActionResult Update(UpdateCategoryDto model)
        {
            Category category = _unitOfWork.CategoryRepository.GetById(model.Id);

            category.Name = model.Name;
            category.Description = model.Description;

            _unitOfWork.Commit();

            //_unitOfWork.CategoryRepository.Update(category);
            //_unitOfWork.Commit();

            return Ok(model);
        }
    }
}
