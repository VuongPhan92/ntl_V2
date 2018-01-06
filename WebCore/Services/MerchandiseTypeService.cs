using Data;
using Domain.Command;
using Domain.IServices;
using Domain.ViewModels;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using System.Collections.Generic;
using WebCore.Command;
using WebCore.Queries;
using System;

namespace WebCore.Services
{
    public class MerchandiseTypeService : IService<MerchandiseType>, IMerchandiseTypeService
    {
        private readonly IQueryHandler<MerchandiseTypeGetAllQuery, IEnumerable<MerchandiseType>> getAllMerchandiseTypeHandler;
        private readonly IQueryHandler<MerchandiseTypeGetActiveQuery, IEnumerable<MerchandiseType>> getActiveMerchandiseTypeHandler;
        private readonly IQueryHandler<MerchandiseTypeGetByIdQuery, MerchandiseType> getMerchandiseTypeByIdHandler;
        private readonly ICommandHandler<MerchandiseTypeAddCommand> addMerchandiseTypeHandler;
        private readonly ICommandHandler<MerchandiseTypeDeleteCommand> inactiveMerchandiseTypeHandler;
        private readonly ICommandHandler<MerchandiseTypeActiveUpdateCommand> activeMerchandiseTypeHandler;
        private readonly ICommandHandler<MerchandiseTypeNameUpdateCommand> updateMerchandiseTypeNameHandler;
        private readonly ICommandHandler<MerchandiseTypeTypeUpdateCommand> updateMerchandiseTypeTypeHandler;
        private readonly ICommandHandler<MerchandiseTypeDescriptionUpdateCommand> updateMerchandiseTypeDescriptionHandler;
        private readonly ICommandHandler<MerchandiseTypeUnitUpdateCommand> updateMerchandiseTypeUnitHandler;


        public MerchandiseTypeService(
            IQueryHandler<MerchandiseTypeGetAllQuery, IEnumerable<MerchandiseType>> _getAllMerchandiseTypeHandler,
            ICommandHandler<MerchandiseTypeAddCommand> _addMerchandiseTypeHandler,
            ICommandHandler<MerchandiseTypeDeleteCommand> _inactiveMerchandiseTypeHandler,
            ICommandHandler<MerchandiseTypeNameUpdateCommand> _updateMerchandiseTypeNameHandler,
            ICommandHandler<MerchandiseTypeTypeUpdateCommand> _updateMerchandiseTypeTypeHandler,
            ICommandHandler<MerchandiseTypeDescriptionUpdateCommand> _updateMerchandiseTypeDescriptionHandler,
            ICommandHandler<MerchandiseTypeUnitUpdateCommand> _updateMerchandiseTypeUnitHandler,
            ICommandHandler<MerchandiseTypeActiveUpdateCommand> _activeMerchandiseTypeUnitHandler   ,
            IQueryHandler<MerchandiseTypeGetByIdQuery, MerchandiseType> _getMerchandiseTypeByIdHandler
        )
        {
            getAllMerchandiseTypeHandler = _getAllMerchandiseTypeHandler;
            addMerchandiseTypeHandler = _addMerchandiseTypeHandler;
            inactiveMerchandiseTypeHandler = _inactiveMerchandiseTypeHandler;
            updateMerchandiseTypeDescriptionHandler = _updateMerchandiseTypeDescriptionHandler;
            updateMerchandiseTypeNameHandler = _updateMerchandiseTypeNameHandler;
            updateMerchandiseTypeTypeHandler = _updateMerchandiseTypeTypeHandler;
            updateMerchandiseTypeUnitHandler = _updateMerchandiseTypeUnitHandler;
            activeMerchandiseTypeHandler = _activeMerchandiseTypeUnitHandler;
            getMerchandiseTypeByIdHandler = _getMerchandiseTypeByIdHandler;
        }

        public IEnumerable<MerchandiseType> GetActiveMerchandiseTypes()
        {
            return getActiveMerchandiseTypeHandler.Handle(new MerchandiseTypeGetActiveQuery { });
        }

        public IEnumerable<MerchandiseType> GetAllMerchandiseTypes()
        {
            return getAllMerchandiseTypeHandler.Handle(new MerchandiseTypeGetAllQuery { });
        }

        public void AddMerchandise(MerchandiseTypeVM merchandiseTypeVM)
        {
            addMerchandiseTypeHandler.Handle(new MerchandiseTypeAddCommand { MerchandiseType = merchandiseTypeVM ,UserId=merchandiseTypeVM.UserId});
        }

        public MerchandiseType GetMerchandiseTypeById(string merchandiseId)
        {
            return getMerchandiseTypeByIdHandler.Handle(new MerchandiseTypeGetByIdQuery { MerchandiseTypeId = merchandiseId });
        }

        public void UpdateMerchandiseTypeName(string merchandiseId, string name, string userId)
        {
            updateMerchandiseTypeNameHandler.Handle(new MerchandiseTypeNameUpdateCommand { MerchandiseTypeId = merchandiseId, Name = name, UserId = userId });
        }

        public void UpdateMerchandiseTypeUnit(string merchandiseId, string unit, string userId)
        {
            updateMerchandiseTypeUnitHandler.Handle(new MerchandiseTypeUnitUpdateCommand { MerchandiseTypeId = merchandiseId, CalculationUnit = unit, UserId = userId });
        }

        public void UpdateMerchandiseTypeDescription(string merchandiseId, string description, string userId)
        {
            updateMerchandiseTypeDescriptionHandler.Handle(new MerchandiseTypeDescriptionUpdateCommand { MerchandiseTypeId = merchandiseId, Description = description, UserId = userId });
        }

        public void UpdateMerchandiseTypeType(string merchandiseId, string type, string userId)
        {
            updateMerchandiseTypeTypeHandler.Handle(new MerchandiseTypeTypeUpdateCommand { MerchandiseTypeId = merchandiseId, Type = type, UserId = userId });
        }

        public void ActiveMerchandiseType(string merchandiseId, string userId)
        {
            activeMerchandiseTypeHandler.Handle(new MerchandiseTypeActiveUpdateCommand { MerchandiseTypeId = merchandiseId, UserId = userId });
        }

        public void InactiveMerchandise(string merchandiseId, string userId)
        {
            inactiveMerchandiseTypeHandler.Handle(new MerchandiseTypeDeleteCommand { MerchandiseId = merchandiseId });
        }
    }
}