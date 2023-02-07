using ECommerceV2.Shared.Entities.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;

namespace EcommerceV2.Entities.Concrete
{
    public class MUser : EntityBase, IEntity
    {
        public string? CitizenshipId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Country { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[]? PasswordHash { get; set; }
        public EAuthority Authority { get; set; }
        public MUserFile? UserPicture { get; set; }
        ICollection<MAction>? Actions { get; set; }
        ICollection<MWish>? Wishes { get; set; }

    }
}