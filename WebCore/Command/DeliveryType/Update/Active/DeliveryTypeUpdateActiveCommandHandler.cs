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
    public class DeliveryTypeUpdateActiveCommandHandler : ICommandHandler<DeliveryTypeActiveUpdateCommand>
    {
        private readonly IActivityService iActivityServices;
        public DeliveryTypeUpdateActiveCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }

        public void Handle(DeliveryTypeActiveUpdateCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //update
                    var deliveryTypeEntity = uow.Repository<DeliveryType>().GetById(p => p.DeliveryId.Equals(command.DeliveryTypeId));
                    var previousVal = deliveryTypeEntity.DeletedDate;
                    deliveryTypeEntity.LastModifiedDate = System.DateTime.Now;
                    deliveryTypeEntity.DeletedDate = null;
                    uow.Repository<DeliveryType>().Update(deliveryTypeEntity);
                    uow.SubmitChanges();
                    //log

                    //Inset new Activity
                    var activity = new Activity()
                    {
                        Source = "Loại hàng",
                        Source_Id = deliveryTypeEntity.DeliveryId,
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
