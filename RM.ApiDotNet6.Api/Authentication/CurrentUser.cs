using RM.ApiDotNet6.Domain.Authentication;

namespace RM.ApiDotNet6.Api.Authentication
{
    public class CurrentUser : ICurrentUser
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Permissions { get; set; } = string.Empty;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var claims = httpContext?.User.Claims;

            if (claims == null) return;

            if (claims.Any(x => x.Type == "Id"))
                Id = Convert.ToInt32(claims.First(x => x.Type == "Id").Value);

            if (claims.Any(x => x.Type == "Email"))
                Email = claims.First(x => x.Type == "Email").Value;

            if (claims.Any(x => x.Type == "Permissions"))
                Permissions = claims.First(x => x.Type == "Permissions").Value;
        }
    }
}
