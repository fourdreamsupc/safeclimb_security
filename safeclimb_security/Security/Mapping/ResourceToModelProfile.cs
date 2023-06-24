 using AutoMapper;
 using safeclimb_security.Security.Subscriptions.Domain.Models;
 using safeclimb_security.Security.Subscriptions.Resources;

 namespace safeclimb_security.Security.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveSubscriptionResource, Subscription>();
        }
    }
}