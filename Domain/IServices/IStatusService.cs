using Data;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IStatusService
    {
        /// <summary>
        /// Get all statuses
        /// </summary>
        IEnumerable<Status> GetAllStatus();

        /// <summary>
        /// Get all active statuses
        /// </summary>
        IEnumerable<Status> GetActiveStatus();

        /// <summary>
        /// Get specific active status by guid
        /// </summary>
        /// <param name="statusId">Guid of status</param>
        Status GetStatusById(string statusId);

        /// <summary>
        /// Add new status into database
        /// </summary>
        /// <param name="statusVM">Instance of status view model</param>
        void AddStatus(StatusVM statusVM);

        /// <summary>
        /// Update bol status by bol code
        /// </summary>
        /// <param name="bolCode">Code of bol</param>
        void UpdateBolStatusByCode(string bolCode);

        /// <summary>
        /// Update bol status by bol id
        /// </summary>
        /// <param name="bolId">Id of bol</param>
        void UpdateBolStatusById(string bolId);

        /// <summary>
        /// Update specific status name 
        /// </summary>
        /// <param name="statusId">Guid of status</param>
        /// <param name="name">Name of status</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateStatusName(string statusId, string name, string userId);

        /// <summary>
        /// Update specific status description 
        /// </summary>
        /// <param name="statusId">Guid of status</param>
        /// <param name="description">Description of status</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateStatusDescription(string statusId, string description, string userId);

        /// <summary>
        /// Inactive specific status 
        /// </summary>
        /// <param name="statusId">Guid of status</param>
        /// <param name="userId">Guid of user</param>
        void InactiveStatus(string statusId, string userId);

        /// <summary>
        /// Active specific status 
        /// </summary>
        /// <param name="statusId">Guid of status</param>
        /// <param name="userId">Guid of user</param>
        void ActiveStatus(string statusId, string userId);
    }
}
