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
    public class StatusAddCommandHandler:ICommandHandler<StatusAddCommand>
    {
        private readonly IActivityService iActivityServices;
        public StatusAddCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }

        public void Handle(StatusAddCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //add
                    var statusEntity = new Status()
                    {
                        StatusId = Guid.NewGuid().ToString(),
                        Name = command.Status.Name,
                        Description = command.Status.Description,
                        CreatedDate = System.DateTime.Now,
                        LastModifiedDate = System.DateTime.Now
                    };
                    uow.Repository<Status>().Add(statusEntity);
                    uow.SubmitChanges();
                    //Insert new Activity
                    var activity = new Activity();
                    activity.Source = "Trạng thái";
                    activity.Source_Id = statusEntity.StatusId;
                    activity.Action = "Tạo";
                    activity.Current_value = statusEntity.Name;
                    activity.CreatedDate = System.DateTime.Now;
                    activity.CreatedBy = command.Status.UserId;
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
