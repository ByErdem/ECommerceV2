using ECommerceV2.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public byte[]? PasswordHash { get; set; }
        public EAuthority Authority { get; set; }
        public string? UserPicture { get; set; }
    }
}
