using Core.Entities;

namespace restapi_base.Helpers.Interfaces
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);
    }
}
