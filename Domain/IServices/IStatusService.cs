using Data;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAllStatusCode();
    }
}
