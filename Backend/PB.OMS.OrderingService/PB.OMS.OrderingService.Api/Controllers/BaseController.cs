using Microsoft.AspNetCore.Mvc;

namespace PB.OMS.OrderingService.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    //[Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}