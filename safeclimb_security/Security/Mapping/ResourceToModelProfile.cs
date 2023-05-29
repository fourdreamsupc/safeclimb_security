 using AutoMapper;
 using safeclimb_security.Security.Subscriptions.Domain.Models;
 using safeclimb_security.Security.Subscriptions.Resources;

 namespace safeclimb_security.Security.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
           /*CreateMap<UpdateAgencyRequest, Agency>()
                .ForAllMembers(options => options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));*/
            //CreateMap<RegisterCustomerRequest, Customer>();
            /*CreateMap<UpdateCustomerRequest, Customer>()
                .ForAllMembers(options => options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));*/
            CreateMap<SaveSubscriptionResource, Subscription>();
        }
    }
}