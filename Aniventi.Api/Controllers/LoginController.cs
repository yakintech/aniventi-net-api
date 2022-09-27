using Aniventi.Api.Models.Services.TokenServices;
using Aniventi.Api.Models.TokenServices;
using Aniventi.BLL.Services.UnitOfWork;
using Aniventi.Dto.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Aniventi.Api.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        public IActionResult Index(LoginDto model)
        {
            var userControl = _unitOfWork.UserRepository.Any(q => q.EMail.ToLower().Trim() == model.EMail && q.Password == model.Password);

            //eğer user varsa token oluşturup kullanıcıya göndereceğim! yoksa 404 göndereceğim!

            if (userControl)
            {
                var tokenHandler = new TokenHandler();
                Token token = tokenHandler.CreateAccessToken();


                return Ok(token);
            }
            else
            {
                return Ok();
            }

          
        }
    }
}
