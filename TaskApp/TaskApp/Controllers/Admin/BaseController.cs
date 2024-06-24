using Microsoft.AspNetCore.Mvc;

namespace TaskApp.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase { }
}
