using Data;
using Domain.IServices;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using System.Collections.Generic;
using WebCore.Queries;
using System;

namespace WebCore.Services
{
    public class DeliveryTypeService : IService<DeliveryType>, IDeliveryTypeService
    {
        private readonly IQueryHandler<DeliveryTypeGetAllQuery, IEnumerable<DeliveryType>> getAllDeliveryTypeHandler;
        private readonly IQueryHandler<DeliveryTypeGetActiveQuery, IEnumerable<DeliveryType>> getActiveDeliveryTypeHandler;
        private readonly IQueryHandler<DeliveryTypeGetByIdQuery, DeliveryType> getDeliveryTypeByIdHandler;

        public DeliveryTypeService(
            IQueryHandler<DeliveryTypeGetAllQuery, IEnumerable<DeliveryType>> _getAllDeliveryTypeHandler,
            IQueryHandler<DeliveryTypeGetActiveQuery, IEnumerable<DeliveryType>> _getActiveDeliveryTypeHandler,
            IQueryHandler<DeliveryTypeGetByIdQuery, DeliveryType> _getDeliveryTypeByIdHandler
            )
        {
            getAllDeliveryTypeHandler = _getAllDeliveryTypeHandler;
            getActiveDeliveryTypeHandler = _getActiveDeliveryTypeHandler;
            getDeliveryTypeByIdHandler = _getDeliveryTypeByIdHandler;
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
    }
}
