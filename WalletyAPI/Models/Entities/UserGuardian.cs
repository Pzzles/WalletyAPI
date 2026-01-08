namespace WalletyAPI.Models.Entities
{
    public class UserGuardian
    {
        public Guid DependentId { get; set; }
        public User Dependent { get; set; } = null!;

        public Guid GuardianId { get; set; }
        public User Guardian { get; set; } = null!;

        public DateTime AssignedDate { get; set; }
    }
}
