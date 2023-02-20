using ECommerceV2.Shared.Utilities.Results.ComplexTypes;
using Microsoft.IdentityModel.Tokens;


namespace EcommerceV2.Entities.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? CitizenshipId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PasswordHash { get; set; }
        public EAuthority Authority { get; set; }
        public string? UserPicture { get; set; }
        public bool Blocked { get; set; }
        public SecurityToken Token { get; set; } 
    }
}
