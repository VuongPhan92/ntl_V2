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
    public class DeliveryTypeAddCommandHandler : ICommandHandler<DeliveryTypeAddCommand>
    {
        private readonly IActivityService iActivityServices;
        public DeliveryTypeAddCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }

        public void Handle(DeliveryTypeAddCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    var deliveryTypeEntity = new DeliveryType()
                    {
                        DeliveryId = Guid.NewGuid().ToString(),
                        Name = command.DeliveryType.Name,
                        Value = command.DeliveryType.Value,
                        Description = command.DeliveryType.Description,
                        CreatedDate = System.DateTime.Now,
                        LastModifiedDate = System.DateTime.Now
                    };
                    uow.Repository<DeliveryType>().Add(deliveryTypeEntity);
                    uow.SubmitChanges();
                    //Insert new Activity
                    var activity = new Activity()
                    {
                        Source = "Giao nhận",
                        Source_Id = deliveryTypeEntity.DeliveryId,
                        Action = "Tạo",
                        Current_value = deliveryTypeEntity.Name,
                        CreatedDate = System.DateTime.Now,
                        CreatedBy = command.DeliveryType.UserId
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
