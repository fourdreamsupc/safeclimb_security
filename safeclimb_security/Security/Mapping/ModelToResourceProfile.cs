using AutoMapper;
using safeclimb_security.Security.HttpResource;
using safeclimb_security.Security.Security.Domain.Services.Communication;
using safeclimb_security.Security.Subscriptions.Domain.Models;
using safeclimb_security.Security.Subscriptions.Resources;

namespace safeclimb_security.Security.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            //CreateMap<Agency, AuthenticateResponse>();
            //CreateMap<Customer, AuthenticateResponse>();
            CreateMap<Subscription, SubscriptionResource>();
            CreateMap<AuthenticateResponse, AuthenticateAgencyResponse>();
            CreateMap<AuthenticateResponse, AuthenticateCustomerResponse>();            
            CreateMap<Customer, AuthenticateResponse>();
            CreateMap<Agency, AuthenticateResponse>();
        }
    }
}