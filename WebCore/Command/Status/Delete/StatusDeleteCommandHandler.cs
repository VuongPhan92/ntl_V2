﻿using Data;
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
    public class StatusDeleteCommandHandler:ICommandHandler<StatusDeleteCommand>
    {
        private readonly IActivityService iActivityServices;
        public StatusDeleteCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }

        public void Handle(StatusDeleteCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //update
                    var statusEntity = uow.Repository<Status>().GetById(p => p.StatusId.Equals(command.StatusId) && !p.DeletedDate.HasValue);
                    statusEntity.LastModifiedDate = System.DateTime.Now;
                    statusEntity.DeletedDate = System.DateTime.Now;
                    uow.Repository<Status>().Update(statusEntity);
                    uow.SubmitChanges();
                    //Insert new Activity
                    var activity = new Activity();
                    activity.Source = "Trạng thái";
                    activity.Source_Id = statusEntity.StatusId;
                    activity.Action = "Xóa";
                    activity.Current_value = statusEntity.Name;
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
