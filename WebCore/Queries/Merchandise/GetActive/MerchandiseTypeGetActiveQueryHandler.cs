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
    public class MerchandiseTypeGetActiveQueryHandler : IQueryHandler<MerchandiseTypeGetActiveQuery, IEnumerable<MerchandiseType>>
    {
        public IEnumerable<MerchandiseType> Handle(MerchandiseTypeGetActiveQuery query)
        {
            var uow = new UnitOfWork<EF>();
            var result = uow.Repository<MerchandiseType>().GetAll().Where(p => !p.DeletedDate.HasValue);
            uow.Dispose();
            return result;
        }
    }
}
