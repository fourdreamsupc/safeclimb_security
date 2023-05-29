namespace safeclimb_security.Security.Security.Domain.Services.Communication
{
    public class RegisterCustomerRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }

        public string Photo {get; set;}
    }
}