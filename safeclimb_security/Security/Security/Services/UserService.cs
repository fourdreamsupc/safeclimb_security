using AutoMapper;
using safeclimb_security.Security.Connection;
using safeclimb_security.Security.HttpResource;
using safeclimb_security.Security.Security.Authorization.Handlers.Interfaces;
using safeclimb_security.Security.Security.Domain.Services.Communication;
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

        public async Task Authenticate(AuthenticateRequest request)
        {
            //var customer = await _customerRepository.FindByEmailAsync(request.Email);
            //var agency = await _agencyRepository.FindByEmailAsync(request.Email);
            var connectionService = new ConnectionService();
            var customers = await connectionService.GetAllResponse<Customer>("customers");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Email);
            }
            var agencies = await connectionService.GetAllResponse<Agency>("agencies");
            foreach (var customer in agencies)
            {
                Console.WriteLine(customer.Email);
            }
            //Validate
            //if (customer == null || !BCryptNet.Verify(request.Password, customer.PasswordHash))
            //{
            //    if (agency == null || !BCryptNet.Verify(request.Password, agency.PasswordHash))
            //        throw new AppException("Email or password is incorrect.");
            //    
            //    //Authentication successful
            //    var responseAgency = _mapper.Map<AuthenticateResponse>(agency);
            //    responseAgency.Token = _jwtHandler.GenerateToken(agency);
            //    return responseAgency;
            //}
//
            ////Authentication successful
            //var responseCustomer = _mapper.Map<AuthenticateResponse>(customer);
            //responseCustomer.Token = _jwtHandler.GenerateToken(customer);
            //return responseCustomer;
        }
    }
}