namespace Domain.Command
{
    public class BranchPhoneUpdateCommand
    {
        public string BranchId { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
    }
}
