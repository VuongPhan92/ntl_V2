using Data;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IMerchandiseTypeService
    { 
        IEnumerable<MerchandiseType> GetActiveMerchandiseTypes();
        IEnumerable<MerchandiseType> GetAllMerchandiseTypes();
        void AddMerchandise(MerchandiseTypeVM merchandiseTypeVM);
        void DeleteMerchandise(string merchandiseId);
    }
}