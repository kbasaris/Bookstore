using BookStore.Api.Models;
using BookStore.Authentication;
using BookStore.Authentication.Utilities;
using BookStore.Data.Entities;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using System.Web.Http;

namespace HomeCinema.Web.Controllers
{
    // [Authorize(Roles = "Admin")]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IMembershipService _membershipService;
        private readonly IEntityBaseRepository<Error> _errorsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IMembershipService membershipService,
            IEntityBaseRepository<Error> errorsRepository, IUnitOfWork unitOfWork)
        {
            _membershipService = membershipService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public IHttpActionResult Login(LoginViewModel user)
        {

            if (ModelState.IsValid)
            {
                MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

                if (_userContext.User != null)
                {

                    return Ok(new { success = true });
                }
                else
                {
                    return Ok(new { success = false });
                }
            }
            else
                return Ok(new { success = false });

        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register(RegistrationViewModel user)
        {


            if (ModelState.IsValid)
            {

                User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

                if (_user != null)
                {
                    return Ok(new { success = true });
                }
                else
                {
                    return Ok(new { success = false });
                }
            }
            return BadRequest();
        }
    }
}
