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
    public class StatusGetByIdQueryHandler : IQueryHandler<StatusGetByIdQuery, Status>
    {
        public Status Handle(StatusGetByIdQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<Status>().GetById(p=>p.StatusId.Equals(query.StatusId) && !p.DeletedDate.HasValue);
            uow.Dispose();
            return result;
        }
    }
}
