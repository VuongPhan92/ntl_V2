using Data;
using Domain.Command;
using Domain.IServices;
using Infrastructure.Decorator;
using Infrastructure.Repository;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using WebCore.Services;

namespace WebCore.Command
{
    public class BranchAddCommandHandler : ICommandHandler<BranchAddCommand>
    {
        private readonly IActivityService iActivityServices;
        public BranchAddCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }
        public void Handle(BranchAddCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    var branchEntity = new Branch()
                    {
                        BranchId = Guid.NewGuid().ToString(),
                        Name = command.Branch.Name,
                        Address = command.Branch.Address,
                        BranchCode = command.Branch.BranchCode,
                        Email = command.Branch.Email,
                        Phone = command.Branch.Phone,
                        Description = command.Branch.Description,
                        CreatedDate = System.DateTime.Now,
                        LastModifiedDate = System.DateTime.Now
                    };
                    uow.Repository<Branch>().Add(branchEntity);
                    uow.SubmitChanges();
                    //Insert new Activity
                    var activity = new Activity()
                    {
                        Source = "Chi nhánh",
                        Source_Id = branchEntity.BranchId,
                        Action = "Tạo",
                        Current_value = branchEntity.Name,
                        CreatedDate = System.DateTime.Now,
                        CreatedBy = command.Branch.UserId
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
