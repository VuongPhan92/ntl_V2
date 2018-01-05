namespace Domain.Command
{
    public class BranchEmailUpdateCommand
    {
        public string BranchId { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
