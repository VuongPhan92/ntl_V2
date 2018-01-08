using Data;
using Domain.IServices;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using System.Collections.Generic;
using WebCore.Queries;
using System;

namespace WebCore.Services
{
    public class StatusService : IService<Status>, IStatusService
    {
        private readonly IQueryHandler<StatusCodeGetAllQuery, IEnumerable<Status>> getAllStatusCodeHandler;

        public StatusService(
            IQueryHandler<StatusCodeGetAllQuery, IEnumerable<Status>> _getAllStatusCodeHandler)
        {
            getAllStatusCodeHandler = _getAllStatusCodeHandler; 
        }

        public void AactiveStatus(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetActiveStatus()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetAllStatus()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetAllStatusCode()
        {
            return getAllStatusCodeHandler.Handle(new StatusCodeGetAllQuery { });
        }

        public Status GetStatusById(string id)
        {
            throw new NotImplementedException();
        }

        public void InactiveStatus(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBolStatusByCode(string bolCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateBolStatusById(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatusDescription(string id, string description, string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatusName(string id, string name, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
