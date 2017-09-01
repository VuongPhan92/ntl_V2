﻿using Data;
using Domain.IServices;
using Domain.ViewModels;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebCore.Command;
using WebCore.Queries;
using System;

namespace WebCore.Services
{
    public class BolServices : IService<BillOfLanding>, IBolServices
    {
        private readonly IQueryHandler<BolGetAllQuery, IEnumerable<BillOfLanding>> getAllBolHandler;
        private readonly ICommandHandler<BolAddCommand> addBolHandler;
        private readonly ICustomerServices iCusomterservices;
        private readonly ICommandHandler<BolStatusUpdateCommand> bolStatusUpdateHandler;

        public BolServices(
            IQueryHandler<BolGetAllQuery, IEnumerable<BillOfLanding>> _getAllBolHandler,
            ICommandHandler<BolAddCommand> _addBolHandler,
            ICustomerServices _iCusomterservices   ,
            ICommandHandler<BolStatusUpdateCommand> _bolStatusUpdateHandler
            )
        {
            getAllBolHandler = _getAllBolHandler;
            addBolHandler = _addBolHandler;
            iCusomterservices = _iCusomterservices;
            bolStatusUpdateHandler = _bolStatusUpdateHandler;
        }

        public IEnumerable<BillOfLanding> GetAllBol()
        {
            return getAllBolHandler.Handle(new BolGetAllQuery { });
        }
        public List<Customer> ValidateCustomerInfo (BillOfLanding bol, CustomerVM subCommand)
        {
            var sender = iCusomterservices.GetAllCustomer().Where(p => p.Name.Equals(subCommand.SenderName) && p.Phone.Equals(subCommand.SenderPhone));
            var receiver = iCusomterservices.GetAllCustomer().Where(p => p.Name.Equals(subCommand.ReceiverName) && p.Phone.Equals(subCommand.ReceiverPhone));
            if (sender.Count() < 1 && receiver.Count() > 1)
            {
                bol.Customers.Add(new Customer() { Name = subCommand.SenderName, Phone = subCommand.SenderPhone, CreatedDate = System.DateTime.Now });
                return new List<Customer> { receiver.FirstOrDefault() };
            }
            else if (sender.Count() > 1 && receiver.Count() < 1)
            {
                bol.Customers.Add (new Customer() { Name = subCommand.ReceiverName, Phone = subCommand.ReceiverPhone, CreatedDate = System.DateTime.Now });
                return new List<Customer> { sender.FirstOrDefault() };
            }
            else if (sender.Count() > 1 && receiver.Count() > 1)
            {
                return new List<Customer> { sender.FirstOrDefault(),receiver.FirstOrDefault() };
            }
            else
            {
                bol.Customers.Add ( new Customer() { Name = subCommand.SenderName, Phone = subCommand.SenderPhone, CreatedDate = System.DateTime.Now });
                bol.Customers.Add(new Customer() { Name = subCommand.ReceiverName, Phone = subCommand.ReceiverPhone, CreatedDate = System.DateTime.Now });            
                return new List<Customer> { };
            }
        }
        public void CreateNewBol(BolVM command,CustomerVM subCommand)
        {
            BillOfLanding bol = new BillOfLanding();
            //Many to Many relationship handle
            var branchFrom = new Branch() { Id = command.BolFromId };
            var branchTo = new Branch() { Id = command.BolToId };
            var customerList =  ValidateCustomerInfo(bol, subCommand);                
            //End
            bol.AdditionalFee = command.AdditionalFee;
            bol.BolCode = command.BolCode;
            bol.CreatedDate = System.DateTime.Now;
            bol.DeliveryType = command.DeliveryType;
            bol.Prepaid = command.Prepaid;
            bol.MerchandiseType = command.MerchandiseTypeId;
            bol.Liabilities = command.Liabilities;     
            bol.ReceiveDate = System.DateTime.ParseExact(command.ReceiveDate,"dd/M/yyyy",CultureInfo.InvariantCulture);
            bol.ReceiveTime =  System.DateTime.ParseExact(command.ReceiveTime,"HH:mm:ss", CultureInfo.InvariantCulture);
            bol.SendAddress = command.SendAddress;  
            bol.SendDate = System.DateTime.ParseExact(command.SendDate,"dd/M/yyyy", CultureInfo.InvariantCulture);
            bol.StatusCode = command.StatusCode;          
            bol.Total = command.Total;
            bol.Weight = command.Weight;
            bol.Quantity = command.Quantity;
            bol.MixValue = command.MixedValue;
            bol.IsGuarantee = command.IsGuarantee;
            bol.IsOnHand = command.IsOnHand;
            bol.DeclareValue = command.DeclareValue;
            addBolHandler.Handle(new BolAddCommand { BOL = bol, Branches = new List<Branch> { branchFrom, branchTo }, Customers = customerList});                   
        }
        public void UpdateStatus(int bolId)
        {
            bolStatusUpdateHandler.Handle(new BolStatusUpdateCommand { Id = bolId });
        }
    }
}