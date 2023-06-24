using AutoMapper;
using safeclimb_security.Security.Connection;
using safeclimb_security.Security.HttpResource;
using safeclimb_security.Security.Security.Authorization.Handlers.Interfaces;
using safeclimb_security.Security.Security.Domain.Services.Communication;
using safeclimb_security.Security.Security.Exceptions;
using safeclimb_security.Security.Shared.Domain.Services;

namespace safeclimb_security.Security.Security.Services
{
    public class UserService : IUserService
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IJwtHandler jwtHandler, IMapper mapper)
        {
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var connectionService = new ConnectionService();
            var customers = await connectionService.GetAllResponse<Customer>("customers");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Email);
                if (customer.Email != request.Email) continue;
                var responseCustomer = _mapper.Map<AuthenticateResponse>(customer);
                responseCustomer.Token = _jwtHandler.GenerateToken(customer);
                return responseCustomer;

            }
            var agencies = await connectionService.GetAllResponse<Agency>("agencies");
            foreach (var agency in agencies)
            {
                Console.WriteLine(agency.Email);
                if (agency.Email != request.Email) continue;
                var responseCustomer = _mapper.Map<AuthenticateResponse>(agency);
                responseCustomer.Token = _jwtHandler.GenerateToken(agency);
                return responseCustomer;
            }
            throw new AppException("Email or password is incorrect.");
        }
    }
}