using Data;
using Infrastructure.Queries;
using Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;

namespace WebCore.Queries
{
    public class StatusCodeGetAllQueryHandler : IQueryHandler<StatusGetAllQuery, IEnumerable<Status>>
    {
        public IEnumerable<Status> Handle(StatusGetAllQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<Status>().GetAll();
            uow.Dispose();
            return result;
        }
    }
}