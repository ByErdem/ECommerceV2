using ECommerceV2.Shared.Entities.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;

namespace EcommerceV2.Entities.Concrete
{
    public class MUser : EntityBase, IEntity
    {
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
        public bool Blocked { get; set; } //Kullanıcının engellenip engellenmediğini tespit etmeye yardımcı olur.
        public MUserFile? UserFile { get; set; }
        public ICollection<MAction>? Actions { get; set; }
        public ICollection<MWish>? Wishes { get; set; }
        public ICollection<MStock>? Stocks { get; set; }
        public ICollection<MSentMessage>? SentMessages { get; set; }
        public ICollection<MReceivedMessage>? ReceivedMessages { get; set; }
    }
}