using safeclimb_security.Security.Subscriptions.Domain.Models;
using safeclimb_security.Security.Subscriptions.Domain.Services.Communication;

namespace safeclimb_security.Security.Subscriptions.Domain.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<SubscriptionResponse> GetById(int id);
        Task<SubscriptionResponse> SaveAsync(Subscription subscription);
        Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription);
        Task<SubscriptionResponse> DeleteAsync(int id);
    }
}