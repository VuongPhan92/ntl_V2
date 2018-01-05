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
    class DeliveryTypeDeleteCommandHandler : ICommandHandler<DeliveryTypeDeleteCommand>
    {
        private readonly IActivityService iActivityServices;
        public DeliveryTypeDeleteCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }

        public void Handle(DeliveryTypeDeleteCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //update
                    var deliveryTypeEntity = uow.Repository<DeliveryType>().GetById(p => p.DeliveryId.Equals(command.DeliveryTypeId) && !p.DeletedDate.HasValue);
                    deliveryTypeEntity.LastModifiedDate = System.DateTime.Now;
                    deliveryTypeEntity.DeletedDate = System.DateTime.Now;
                    uow.Repository<DeliveryType>().Update(deliveryTypeEntity);
                    uow.SubmitChanges();
                    //Insert new Activity
                    var activity = new Activity()
                    {
                        Source = "Giao nhận",
                        Source_Id = deliveryTypeEntity.DeliveryId,
                        Action = "Xóa",
                        Current_value = deliveryTypeEntity.Name,
                        CreatedDate = deliveryTypeEntity.DeletedDate,
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
