using safeclimb_security.Security.Shared.Domain.Services.Communication;
using safeclimb_security.Security.Subscriptions.Domain.Models;

namespace safeclimb_security.Security.Subscriptions.Domain.Services.Communication
{
    public class SubscriptionResponse : BaseResponse<Subscription>
    {
        //UNHAPPY
        public SubscriptionResponse(string message) : base(message)
        {
            
        }
        //HAPPY
        public SubscriptionResponse(Subscription resource) : base(resource)
        {
            
        }
    }
}