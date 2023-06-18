using safeclimb_security.Security.Security.Domain.Services.Communication;

namespace safeclimb_security.Security.Shared.Domain.Services
{
    public interface IUserService
    {
        Task Authenticate(AuthenticateRequest request);
    }
}