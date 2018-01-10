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
    public class DeliveryTypeDescriptionUpdateCommandHandler : ICommandHandler<DeliveryTypeDescriptionUpdateCommand>
    {
        private readonly IActivityService iActivityServices;
        public DeliveryTypeDescriptionUpdateCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }

        public void Handle(DeliveryTypeDescriptionUpdateCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //update
                    var deliveryTypeEntity = uow.Repository<DeliveryType>().GetById(p => p.DeliveryId.Equals(command.DeliveryTypeId) && !p.DeletedDate.HasValue);
                    var previousVal = deliveryTypeEntity.Description;
                    deliveryTypeEntity.LastModifiedDate = System.DateTime.Now;
                    deliveryTypeEntity.Name = command.Description;
                    uow.Repository<DeliveryType>().Update(deliveryTypeEntity);
                    uow.SubmitChanges();
                    //Inset new Activity
                    var activity = new Activity()
                    {
                        Source = "Chi nhánh",
                        Source_Id = deliveryTypeEntity.DeliveryId,
                        Action = "Sửa",
                        Previous_value = previousVal,
                        Current_value = command.Description,
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
