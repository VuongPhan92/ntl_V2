using Data;
using Domain.IServices;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using System.Collections.Generic;
using WebCore.Queries;
using System;
using Domain.Command;
using Domain.ViewModels;

namespace WebCore.Services
{
    public class StatusService : IService<Status>, IStatusService
    {
        private readonly IQueryHandler<StatusGetAllQuery, IEnumerable<Status>> getAllStatusHandler;
        private readonly IQueryHandler<StatusGetActiveQuery, IEnumerable<Status>> getActiveStatusHandler;
        private readonly IQueryHandler<StatusGetByIdQuery, Status> getStatusByIdHandler;
        private readonly ICommandHandler<StatusAddCommand> addStatusHandler;
        private readonly ICommandHandler<StatusUpdateActiveCommand> activeStatusHandler;
        private readonly ICommandHandler<StatusDeleteCommand> inactiveStatusHandler;
        private readonly ICommandHandler<StatusUpdateNameCommand> updateStatusNameHandler;
        private readonly ICommandHandler<StatusUpdateDescriptionCommand> updateStatusDescriptionHandler;

        public StatusService(
            IQueryHandler<StatusGetAllQuery, IEnumerable<Status>> _getAllStatusHandler,
            IQueryHandler<StatusGetActiveQuery, IEnumerable<Status>> _getActiveStatusHandler,
            IQueryHandler<StatusGetByIdQuery, Status> _getStatusByIdHandler,
            ICommandHandler<StatusUpdateActiveCommand> _activeStatusHandler,
            ICommandHandler<StatusDeleteCommand> _inactiveStatusHandler,
            ICommandHandler<StatusUpdateNameCommand> _updateStatusNameHandler,
            ICommandHandler<StatusUpdateDescriptionCommand> _updateStatusDescriptionHandler,
            ICommandHandler<StatusAddCommand> _addStatusHandler
            )
        {
            getAllStatusHandler = _getAllStatusHandler;
            getActiveStatusHandler = _getActiveStatusHandler;
            getStatusByIdHandler = _getStatusByIdHandler;
            activeStatusHandler = _activeStatusHandler;
            inactiveStatusHandler = _inactiveStatusHandler;
            updateStatusNameHandler = _updateStatusNameHandler;
            updateStatusDescriptionHandler = _updateStatusDescriptionHandler;
            addStatusHandler = _addStatusHandler;
        }

        public void ActiveStatus(string statusId, string userId)
        {
            activeStatusHandler.Handle(new StatusUpdateActiveCommand { StatusId = statusId, UserId = userId });
        }

        public IEnumerable<Status> GetActiveStatus()
        {
            return getActiveStatusHandler.Handle(new StatusGetActiveQuery { });
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return getAllStatusHandler.Handle(new StatusGetAllQuery { });
        }

        public Status GetStatusById(string statusId)
        {
            return getStatusByIdHandler.Handle(new StatusGetByIdQuery() { StatusId = statusId });
        }

        public void InactiveStatus(string statusId, string userId)
        {
            inactiveStatusHandler.Handle(new StatusDeleteCommand { StatusId = statusId, UserId = userId });
        }

        public void UpdateBolStatusByCode(string bolCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateBolStatusById(string bolId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatusDescription(string statusId, string description, string userId)
        {
            updateStatusDescriptionHandler.Handle(new StatusUpdateDescriptionCommand { StatusId = statusId, Description = description, UserId = userId });
        }

        public void UpdateStatusName(string statusId, string name, string userId)
        {
            updateStatusNameHandler.Handle(new StatusUpdateNameCommand { StatusId = statusId, Name = name, UserId = userId });
        }

        public void AddStatus(StatusVM statusVM)
        {
            addStatusHandler.Handle(new StatusAddCommand { Status = statusVM });
        }
    }
}
