using Data;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAllStatus();
        IEnumerable<Status> GetActiveStatus();
        Status GetStatusById(string id);
        void UpdateBolStatusByCode(string bolCode);
        void UpdateBolStatusById(string id);
        void UpdateStatusName(string id, string name, string userId);
        void UpdateStatusDescription(string id, string description, string userId);
        void InactiveStatus(string id,string userId);
        void AactiveStatus(string id, string userId);
    }
}
