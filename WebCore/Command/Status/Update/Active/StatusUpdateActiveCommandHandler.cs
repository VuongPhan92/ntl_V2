using Data;
using Domain.Command;
using Domain.IServices;
using Infrastructure.Decorator;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Command
{
    public class StatusUpdateActiveCommandHandler : ICommandHandler<StatusUpdateActiveCommand>
    {
        private readonly IActivityService iActivityServices;
        public StatusUpdateActiveCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }
        public void Handle(StatusUpdateActiveCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //update
                    var statusEntity = uow.Repository<Status>().GetById(p => p.StatusId.Equals(command.StatusId));
                    var previousVal = statusEntity.DeletedDate;
                    statusEntity.LastModifiedDate = System.DateTime.Now;
                    statusEntity.DeletedDate = null;
                    uow.Repository<Status>().Update(statusEntity);
                    uow.SubmitChanges();
                    //Insert new Activity
                    var activity = new Activity()
                    {
                        Source = "Trạng thái",
                        Source_Id = statusEntity.StatusId,
                        Action = "Sửa",
                        Previous_value = previousVal.ToString(),
                        Current_value = null,
                        CreatedDate = System.DateTime.Now,                      
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
