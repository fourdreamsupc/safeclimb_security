namespace safeclimb_security.Security.Security.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        //public string GenerateToken(Customer customer);
        //public string GenerateToken(Agency agency);
        public int? ValidateToken(string token);
        
    }
}