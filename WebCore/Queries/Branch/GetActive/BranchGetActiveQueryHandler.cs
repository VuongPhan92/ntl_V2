using Data;
using Infrastructure.Queries;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Queries
{
    public class BranchGetActiveQueryHandler : IQueryHandler<BranchGetActiveQuery, IEnumerable<Branch>>
    {
        public IEnumerable<Branch> Handle(BranchGetActiveQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<Branch>().GetAll().Where(p=> !p.DeletedDate.HasValue);
            uow.Dispose();
            return result;
        }
    }
}