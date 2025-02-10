using RM.ApiDotNet6.Domain.Entities;

namespace RM.ApiDotNet6.Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(User user);
    }
}
