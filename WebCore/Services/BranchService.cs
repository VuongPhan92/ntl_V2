using Data;
using Domain.Command;
using Domain.IServices;
using Domain.ViewModels;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using System.Collections.Generic;
using WebCore.Queries;
using System;

namespace WebCore.Services
{
    public class BranchService : IService<Branch>, IBranchService
    {
        private readonly IQueryHandler<BranchGetByIdQuery, Branch> getBranchByIdHandler;
        private readonly IQueryHandler<BranchGetAllQuery, IEnumerable<Branch>> getAllBranchHandler;
        private readonly IQueryHandler<BranchGetActiveQuery, IEnumerable<Branch>> getActiveBranchHandler;
        private readonly ICommandHandler<BranchAddCommand> addBranchHandler;
        private readonly ICommandHandler<BranchUpdateNameCommand> updateBranchNameHandler;
        private readonly ICommandHandler<BranchAddressUpdateCommand> updateBranchAddressHandler;
        private readonly ICommandHandler<BranchPhoneUpdateCommand> updateBranchPhoneHandler;
        private readonly ICommandHandler<BranchEmailUpdateCommand> updateBranchEmailHandler;
        private readonly ICommandHandler<BranchDeleteCommand> inactiveBranchHandler;
        private readonly ICommandHandler<BranchUpdateCodeCommand> updateBranchCodeHandler;
        private readonly ICommandHandler<BranchActiveUpdateCommand> activeBranchHandler;


        public BranchService(
            IQueryHandler<BranchGetActiveQuery, IEnumerable<Branch>> _getActiveBranchHandler,
            IQueryHandler<BranchGetAllQuery, IEnumerable<Branch>> _getAllBranchHandler,
            IQueryHandler<BranchGetByIdQuery, Branch> _getBranchByIdHandler,
            ICommandHandler<BranchAddCommand> _addBranchHandler,
            ICommandHandler<BranchUpdateNameCommand> _updateBranchNameHandler,
            ICommandHandler<BranchAddressUpdateCommand> _updateBranchAddressHandler,
            ICommandHandler<BranchPhoneUpdateCommand> _updateBranchPhoneHandler,
            ICommandHandler<BranchEmailUpdateCommand> _updateBranchEmailHandler,
            ICommandHandler<BranchDeleteCommand> _inactiveBranchHandler,
            ICommandHandler<BranchUpdateCodeCommand> _updateBranchCodeHandler,
            ICommandHandler<BranchActiveUpdateCommand> _activeBranchHandler
            )
        {
            getActiveBranchHandler = _getActiveBranchHandler;
            getAllBranchHandler = _getAllBranchHandler;
            getBranchByIdHandler = _getBranchByIdHandler;
            addBranchHandler = _addBranchHandler;
            updateBranchNameHandler = _updateBranchNameHandler;
            updateBranchAddressHandler = _updateBranchAddressHandler;
            updateBranchPhoneHandler = _updateBranchPhoneHandler;
            updateBranchEmailHandler = _updateBranchEmailHandler;
            inactiveBranchHandler = _inactiveBranchHandler;
            updateBranchCodeHandler = _updateBranchCodeHandler;
            activeBranchHandler = _activeBranchHandler;
        }

        public IEnumerable<Branch> GetActiveBranches()
        {
            return getActiveBranchHandler.Handle(new BranchGetActiveQuery { });
        }

        public IEnumerable<Branch> GetAllBranches()
        {
            return getAllBranchHandler.Handle(new BranchGetAllQuery { });
        }

        public Branch GetBranchById(string branchId) {
            return getBranchByIdHandler.Handle(new BranchGetByIdQuery { BranchId = branchId });
        }

        public void AddBranch(BranchVM branchVM)
        {                   
            addBranchHandler.Handle(new BranchAddCommand { Branch = branchVM });
        }

        public void UpdateBranchName(string branchId, string name,string userId)
        {
            updateBranchNameHandler.Handle(new BranchUpdateNameCommand { BranchId = branchId, Name = name,UserId=userId });
        }

        public void UpdateBranchAddress(string branchId, string address, string userId)
        {
            updateBranchAddressHandler.Handle(new BranchAddressUpdateCommand { BranchId = branchId, Address = address, UserId = userId });
        }

        public void UpdateBranchPhone(string branchId, string phone, string userId)
        {
            updateBranchPhoneHandler.Handle(new BranchPhoneUpdateCommand { BranchId = branchId, Phone = phone, UserId = userId });
        }

        public void UpdateBranchEmail(string branchId, string email, string userId)
        {
            updateBranchEmailHandler.Handle(new BranchEmailUpdateCommand { BranchId = branchId, Email = email, UserId = userId });
        }

        public void UpdateBranchCode(string branchId, string branchCode, string userId)
        {
            updateBranchCodeHandler.Handle(new BranchUpdateCodeCommand { BranchId = branchId, BranchCode = branchCode, UserId = userId });
        }     

        public void ActiveBranch(string branchId, string userId)
        {
            activeBranchHandler.Handle(new BranchActiveUpdateCommand { BranchId = branchId, UserId = userId });
        }

        public void InactiveBranch(string branchId, string userId)
        {
            inactiveBranchHandler.Handle(new BranchDeleteCommand { BranchId = branchId, UserId = userId });
        }
    }
}