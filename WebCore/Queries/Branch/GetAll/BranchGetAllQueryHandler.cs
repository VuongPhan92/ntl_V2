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
    public class BranchGetAllQueryHandler : IQueryHandler<BranchGetAllQuery, IEnumerable<Branch>>
    {
        public IEnumerable<Branch> Handle(BranchGetAllQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<Branch>().GetAll();
            uow.Dispose();
            return result;
        }
    }
}