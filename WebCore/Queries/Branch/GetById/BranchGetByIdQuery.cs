using Data;
using Infrastructure.Queries;

namespace WebCore.Queries
{
    public class BranchGetByIdQuery : IQuery<Branch>
    {
        public string BranchId { get; set; }
    }
}
