using System;

namespace Domain.ViewModels
{
    public class BranchVM
    {
        public string Name { get; set; }
        public Nullable<int> Type { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BranchCode { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
