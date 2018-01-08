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
    public class BranchDeleteCommandHandler : ICommandHandler<BranchDeleteCommand>
    {
        private readonly IActivityService iActivityServices;
        public BranchDeleteCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }
        public void Handle(BranchDeleteCommand command)
        {
           using(var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //update
                    var branchEntity = uow.Repository<Branch>().GetById(p=>p.BranchId.Equals(command.BranchId)&& !p.DeletedDate.HasValue);
                    branchEntity.LastModifiedDate = System.DateTime.Now;
                    branchEntity.DeletedDate = System.DateTime.Now;
                    uow.Repository<Branch>().Update(branchEntity);
                    uow.SubmitChanges();
                    //Insert new Activity
                    var activity = new Activity();
                    activity.Source = "Chi nhánh";
                    activity.Source_Id = branchEntity.BranchId;
                    activity.Action = "Xóa";
                    activity.Current_value = branchEntity.Name;
                    activity.CreatedDate = System.DateTime.Now;
                    activity.CreatedBy = command.UserId;
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
