using Data;
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
    }
}
