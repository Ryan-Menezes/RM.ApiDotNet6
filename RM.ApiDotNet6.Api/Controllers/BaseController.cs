using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RM.ApiDotNet6.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public bool ValidPermission(List<string> permissionUser, List<string> permissionNeeded)
        {
            return permissionNeeded.Any(x => permissionNeeded.Contains(x));
        }

        [NonAction]
        public IActionResult Forbidden()
        {
            var obj = new
            {
                code = "permissao_negada",
                message = "Usuário não tem permissão para acessar esse recurso"
            };

            return new ObjectResult(obj)
            {
                StatusCode = 403
            };
        }
    }
}
