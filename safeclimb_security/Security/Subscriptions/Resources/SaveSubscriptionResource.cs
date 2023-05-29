using System.ComponentModel.DataAnnotations;

namespace safeclimb_security.Security.Subscriptions.Resources
{
    public class SaveSubscriptionResource
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int Price { get; set; }
    }
}