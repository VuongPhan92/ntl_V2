namespace Domain.Command
{
    public class BranchUpdateNameCommand
    {
        public string BranchId { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}
