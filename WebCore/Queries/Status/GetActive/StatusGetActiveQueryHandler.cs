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
    public class StatusGetActiveQueryHandler : IQueryHandler<StatusGetActiveQuery, IEnumerable<Status>>
    {
        public IEnumerable<Status> Handle(StatusGetActiveQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<Status>().GetAll().Where(p=>!p.DeletedDate.HasValue);
            uow.Dispose();
            return result;
        }
    }
}
