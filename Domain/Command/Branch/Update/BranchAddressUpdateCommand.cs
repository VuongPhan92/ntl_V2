namespace Domain.Command
{
    public class BranchAddressUpdateCommand
    {
        public string BranchId { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }
    }
}
