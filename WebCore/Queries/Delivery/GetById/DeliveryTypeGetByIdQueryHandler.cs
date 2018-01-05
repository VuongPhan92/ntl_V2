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
    public class DeliveryTypeGetByIdQueryHandler : IQueryHandler<DeliveryTypeGetByIdQuery, DeliveryType>
    {
        public DeliveryType Handle(DeliveryTypeGetByIdQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<DeliveryType>().GetById(p => p.DeliveryId.Equals(query.DeliveryTypeId) && !p.DeletedDate.HasValue);
            uow.Dispose();
            return result;
        }
    }
}
