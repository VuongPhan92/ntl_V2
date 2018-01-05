using Data;
using Domain.Command;
using Domain.IServices;
using Infrastructure.Decorator;
using Infrastructure.Repository;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace WebCore.Command
{
    public class BranchAddressUpdateCommandHandler : ICommandHandler<BranchAddressUpdateCommand>
    {
        private readonly IActivityService iActivityServices;
        public BranchAddressUpdateCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }
        public void Handle(BranchAddressUpdateCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //update
                    var branchEntity = uow.Repository<Branch>().GetById(p=>p.BranchId.Equals(command.BranchId)&& !p.DeletedDate.HasValue);
                    var previousVal  = branchEntity.Address;
                    branchEntity.LastModifiedDate = System.DateTime.Now;
                    branchEntity.Address = command.Address;
                    uow.Repository<Branch>().Update(branchEntity);
                    uow.SubmitChanges();
                    //log

                    //Inset new Activity
                    var activity = new Activity()
                    {
                        Source = "Chi nhánh",
                        Source_Id = branchEntity.BranchId,
                        Action = "Sửa",
                        Previous_value = previousVal,
                        Current_value = command.Address,
                        CreatedDate = branchEntity.CreatedDate,
                        CreatedBy = command.UserId
                    };
                    iActivityServices.AddActivity(new ActivityAddCommand { Activity = activity });
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
