using Data;
using Domain.IServices;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using System.Collections.Generic;
using WebCore.Queries;
using System;
using Domain.ViewModels;
using Domain.Command;

namespace WebCore.Services
{
    public class DeliveryTypeService : IService<DeliveryType>, IDeliveryTypeService
    {
        private readonly IQueryHandler<DeliveryTypeGetAllQuery, IEnumerable<DeliveryType>> getAllDeliveryTypeHandler;
        private readonly IQueryHandler<DeliveryTypeGetActiveQuery, IEnumerable<DeliveryType>> getActiveDeliveryTypeHandler;
        private readonly IQueryHandler<DeliveryTypeGetByIdQuery, DeliveryType> getDeliveryTypeByIdHandler;
        private readonly ICommandHandler<DeliveryTypeActiveUpdateCommand> activeDeliveryTypeHandler;
        private readonly ICommandHandler<DeliveryTypeAddCommand> addDeliveryTypeHandler;
        private readonly ICommandHandler<DeliveryTypeDeleteCommand> inactiveDeliveryHandler;
        private readonly ICommandHandler<DeliveryTypeNameUpdateCommand> updateDeliveryTypeNameHandler;
        private readonly ICommandHandler<DeliveryTypeValueUpdateCommand> updateDeliveryTypeValueHandler;
        private readonly ICommandHandler<DeliveryTypeDescriptionUpdateCommand> updateDeliveryTypeDescriptionHandler;

        public DeliveryTypeService(
            IQueryHandler<DeliveryTypeGetAllQuery, IEnumerable<DeliveryType>> _getAllDeliveryTypeHandler,
            IQueryHandler<DeliveryTypeGetActiveQuery, IEnumerable<DeliveryType>> _getActiveDeliveryTypeHandler,
            ICommandHandler<DeliveryTypeAddCommand> _addDeliveryTypeCommandHandler,
            IQueryHandler<DeliveryTypeGetByIdQuery, DeliveryType> _getDeliveryTypeByIdHandler,
            ICommandHandler<DeliveryTypeActiveUpdateCommand> _activeDeliveryTypeHandler,
            ICommandHandler<DeliveryTypeDeleteCommand> _inactiveDeliveryHandler,
            ICommandHandler<DeliveryTypeNameUpdateCommand> _updateDeliveryTypeNameHandler,
            ICommandHandler<DeliveryTypeValueUpdateCommand> _updateDeliveryTypeValueHandler,
            ICommandHandler<DeliveryTypeDescriptionUpdateCommand> _updateDeliveryTypeDescriptionHandler
            )
        {
            getAllDeliveryTypeHandler = _getAllDeliveryTypeHandler;
            getActiveDeliveryTypeHandler = _getActiveDeliveryTypeHandler;
            getDeliveryTypeByIdHandler = _getDeliveryTypeByIdHandler;
            activeDeliveryTypeHandler = _activeDeliveryTypeHandler;
            inactiveDeliveryHandler = _inactiveDeliveryHandler;
            addDeliveryTypeHandler = _addDeliveryTypeCommandHandler;
            updateDeliveryTypeDescriptionHandler = _updateDeliveryTypeDescriptionHandler;
            updateDeliveryTypeNameHandler = _updateDeliveryTypeNameHandler;
            updateDeliveryTypeValueHandler = _updateDeliveryTypeValueHandler;
        }

        public IEnumerable<DeliveryType> GetActiveDeliveryTypes()
        {
            return getActiveDeliveryTypeHandler.Handle(new DeliveryTypeGetActiveQuery { });
        }

        public IEnumerable<DeliveryType> GetAllDeliveryTypes()
        {
            return getAllDeliveryTypeHandler.Handle(new DeliveryTypeGetAllQuery { });
        }

        public DeliveryType GetDeliveryTypeById(string deliveryId)
        {
            return getDeliveryTypeByIdHandler.Handle(new DeliveryTypeGetByIdQuery { DeliveryTypeId = deliveryId});
        }

        public void AddDeliveryType(DeliveryTypeVM deliveryTypeVM)
        {
            addDeliveryTypeHandler.Handle(new DeliveryTypeAddCommand { DeliveryType = deliveryTypeVM});
        }

        public void UpdateDeliveryTypeName(string deliveryTypeId, string name, string userId)
        {
            updateDeliveryTypeNameHandler.Handle(new DeliveryTypeNameUpdateCommand { DeliveryTypeId = deliveryTypeId, Name = name, UserId = userId });
        }

        public void UpdateDeliveryTypeValue(string deliveryTypeId, string value, string userId)
        {
            updateDeliveryTypeValueHandler.Handle(new DeliveryTypeValueUpdateCommand { DeliveryTypeId = deliveryTypeId, Value = value, UserId = userId });
        }

        public void UpdateDeliveryTypeDescription(string deliveryTypeId, string description, string userId)
        {
            updateDeliveryTypeDescriptionHandler.Handle(new DeliveryTypeDescriptionUpdateCommand { DeliveryTypeId = deliveryTypeId, Description = description, UserId = userId });
        }

        public void ActiveDeliveryType(string deliveryTypeId, string userId)
        {
            activeDeliveryTypeHandler.Handle(new DeliveryTypeActiveUpdateCommand { DeliveryTypeId = deliveryTypeId, UserId = userId });
        }

        public void InactiveDeliveryType(string deliveryTypeId, string userId)
        {
            inactiveDeliveryHandler.Handle(new DeliveryTypeDeleteCommand { DeliveryTypeId = deliveryTypeId, UserId = userId });
        }
    }
}
