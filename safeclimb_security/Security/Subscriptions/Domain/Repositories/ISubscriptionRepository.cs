using safeclimb_security.Security.Subscriptions.Domain.Models;

namespace safeclimb_security.Security.Subscriptions.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<IEnumerable<Subscription>> ListById(int id);
        Task AddAsync(Subscription subscription);
        void Update(Subscription subscription);
        void Remove(Subscription subscription);
        Task<Subscription> FindById(int id);
    }
}