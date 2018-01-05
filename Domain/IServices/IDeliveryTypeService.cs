using Data;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IDeliveryTypeService
    {
        /// <summary>
        /// Get all active delivery types
        /// </summary>
        IEnumerable<DeliveryType> GetActiveDeliveryTypes();

        /// <summary>
        /// Get all delivery types
        /// </summary>
        IEnumerable<DeliveryType> GetAllDeliveryTypes();

        /// <summary>
        /// Get specific active delivery type by guid
        /// </summary>
        /// <param name="deliveryId">Guid of delivery type</param>
        DeliveryType GetDeliveryTypeById(string deliveryId);

        /// <summary>
        /// Add new delivery type into database
        /// </summary>
        /// <param name="deliveryTypeVM">Instance of delivery type view model</param>
        void AddDeliveryType(DeliveryTypeVM deliveryTypeVM);

        /// <summary>
        /// Update specific delivery type name 
        /// </summary>
        /// <param name="deliveryTypeId">Guid of delivery type</param>
        /// <param name="name">Name of delivery type</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateDeliveryTypeName(string deliveryTypeId, string name, string userId);

        /// <summary>
        /// Update specific delivery type value 
        /// </summary>
        /// <param name="deliveryTypeId">Guid of delivery type</param>
        /// <param name="value">Value of delivery type</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateDeliveryTypeValue(string deliveryTypeId, string value, string userId);

        /// <summary>
        /// Update specific delivery type description 
        /// </summary>
        /// <param name="deliveryTypeId">Guid of delivery type</param>
        /// <param name="description">Description of delivery type</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateDeliveryTypeDescription(string deliveryTypeId, string description, string userId);

        /// <summary>
        /// Active specific inactive delivery type 
        /// </summary>
        /// <param name="deliveryTypeId">Guid of delivery type</param>
        /// <param name="userId">Guid of user</param>
        void ActiveDeliveryType(string deliveryTypeId,  string userId);

        /// <summary>
        /// Inactive specific delivery type 
        /// </summary>
        /// <param name="deliveryTypeId">Guid of delivery type</param>
        /// <param name="userId">Guid of user</param>
        void InactiveDeliveryType(string deliveryTypeId, string userId);


    }
}
