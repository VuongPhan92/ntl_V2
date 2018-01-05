using Data;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IMerchandiseTypeService
    {
        IEnumerable<MerchandiseType> GetAllMerchandiseType();
        void AddMerchandise(MerchandiseTypeVM merchandiseTypeVM);
        void DeleteMerchandise(string merchandiseId);
    }
}