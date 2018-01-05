using Data;
using Domain.ViewModels;

namespace Domain.Command
{
    public class BranchAddCommand
    {
        public BranchVM Branch { get; set; }
        public string UserId { get; set; }
    }
}
