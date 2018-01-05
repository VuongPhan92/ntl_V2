using Data;
using Domain.Command;
using Domain.IServices;
using Domain.ViewModels;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using System.Collections.Generic;
using WebCore.Command;
using WebCore.Queries;

namespace WebCore.Services
{
    public class MerchandiseTypeService : IService<MerchandiseType>, IMerchandiseTypeService
    {
        private readonly IQueryHandler<MerchandiseTypeGetAllQuery, IEnumerable<MerchandiseType>> getAllMerchandiseTypeHandler;
        private readonly ICommandHandler<MerchandiseTypeAddCommand> addMerchandiseTypeHandler;
        private readonly ICommandHandler<MerchandiseTypeDeleteCommand> deleteMerchandiseTypeHandler;

        public MerchandiseTypeService(
            IQueryHandler<MerchandiseTypeGetAllQuery, IEnumerable<MerchandiseType>> _getAllMerchandiseTypeHandler,
            ICommandHandler<MerchandiseTypeAddCommand> _addMerchandiseTypeHandler,
            ICommandHandler<MerchandiseTypeDeleteCommand> _deleteMerchandiseTypeHandler
        )
        {
            getAllMerchandiseTypeHandler = _getAllMerchandiseTypeHandler;
            addMerchandiseTypeHandler = _addMerchandiseTypeHandler;
            deleteMerchandiseTypeHandler = _deleteMerchandiseTypeHandler;
        }

        public IEnumerable<MerchandiseType> GetAllMerchandiseType()
        {
            return getAllMerchandiseTypeHandler.Handle(new MerchandiseTypeGetAllQuery { });
        }

        public void AddMerchandise(MerchandiseTypeVM merchandiseTypeVM)
        {
            addMerchandiseTypeHandler.Handle(new MerchandiseTypeAddCommand { MerchandiseType = merchandiseTypeVM });
        }

        public void DeleteMerchandise(string merchandiseId)
        {
            deleteMerchandiseTypeHandler.Handle(new MerchandiseTypeDeleteCommand { MerchandiseId = merchandiseId });
        }
    }
}