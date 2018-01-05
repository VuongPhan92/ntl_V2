using Data;
using Infrastructure.Queries;
using Infrastructure.Repository;

namespace WebCore.Queries.GetBranchById
{
    public class BranchGetByIdQueyHandler : IQueryHandler<BranchGetByIdQuery, Branch>
    {
        public Branch Handle(BranchGetByIdQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<Branch>().GetById(p=>p.BranchId.Equals(query.BranchId) && !p.DeletedDate.HasValue);
            uow.Dispose();
            return result;
        }
    }
}
