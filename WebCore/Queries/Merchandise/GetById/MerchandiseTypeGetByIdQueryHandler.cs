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
    public class MerchandiseTypeGetByIdQueryHandler : IQueryHandler<MerchandiseTypeGetByIdQuery, MerchandiseType>
    {
        public MerchandiseType Handle(MerchandiseTypeGetByIdQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<MerchandiseType>().GetById(p => p.MerchandiseId.Equals(query.MerchandiseTypeId) && !p.DeletedDate.HasValue);
            uow.Dispose();
            return result;
        }
    }
}
