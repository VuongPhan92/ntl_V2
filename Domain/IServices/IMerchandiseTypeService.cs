using Data;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IMerchandiseTypeService
    {
        /// <summary>
        /// Get all active merchandise types
        /// </summary>
        IEnumerable<MerchandiseType> GetActiveMerchandiseTypes();

        /// <summary>
        /// Get all merchandise types
        /// </summary>
        IEnumerable<MerchandiseType> GetAllMerchandiseTypes();

        /// <summary>
        /// Get specific active merchandise type by guid
        /// </summary>
        /// <param name="merchandiseId">Guid of delivery type</param>
        MerchandiseType GetMerchandiseTypeById(string merchandiseId);

        /// <summary>
        /// Add new merchandise type into database
        /// </summary>
        /// <param name="merchandiseTypeVM">Instance of merchandise type view model</param>
        void AddMerchandise(MerchandiseTypeVM merchandiseTypeVM);

        /// <summary>
        /// Update specific merchandise type name 
        /// </summary>
        /// <param name="merchandiseId">Guid of merchandise type</param>
        /// <param name="name">Name of merchandise type</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateMerchandiseTypeName(string merchandiseId, string name, string userId);

        /// <summary>
        /// Update specific merchandise type unit 
        /// </summary>
        /// <param name="merchandiseId">Guid of merchandise type</param>
        /// <param name="unit">Unit of merchandise type</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateMerchandiseTypeUnit(string merchandiseId, string unit, string userId);

        /// <summary>
        /// Update specific merchandise type description 
        /// </summary>
        /// <param name="merchandiseId">Guid of merchandise type</param>
        /// <param name="description">Description of merchandise type</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateMerchandiseTypeDescription(string merchandiseId, string description, string userId);

        /// <summary>
        /// Update specific merchandise type type 
        /// </summary>
        /// <param name="merchandiseId">Guid of merchandise type</param>
        /// <param name="type">Type of merchandise type</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateMerchandiseTypeType(string merchandiseId, string type, string userId);

        // <summary>
        /// Active specific merchandise type 
        /// </summary>
        /// <param name="merchandiseId">Guid of merchandise type</param>
        /// <param name="userId">Guid of user</param>
        void ActiveMerchandiseType(string merchandiseId, string userId);

        /// <summary>
        /// Inactive specific merchandise type 
        /// </summary>
        /// <param name="merchandiseId">Guid of merchandise type</param>
        /// <param name="userId">Guid of user</param>
        void InactiveMerchandise(string merchandiseId,string userId);
    }
}