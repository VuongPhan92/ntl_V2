using Data;
using Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Queries.Delivery.GetActive
{
    public class DeliveryTypeGetActiveQueryHandler : IQueryHandler<DeliveryTypeGetActiveQuery, IEnumerable<DeliveryType>>
    {
        public IEnumerable<DeliveryType> Handle(DeliveryTypeGetActiveQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<Branch>().GetAll().Where(p => !p.DeletedDate.HasValue);
            uow.Dispose();
            return result;
        }
    }
}
