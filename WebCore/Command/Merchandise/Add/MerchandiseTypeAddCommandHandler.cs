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
    public class MerchandiseTypeAddCommandHandler : ICommandHandler<MerchandiseTypeAddCommand>
    {
        private readonly IActivityService iActivityServices;
        public MerchandiseTypeAddCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }
        public void Handle(MerchandiseTypeAddCommand command)
        {
           using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //add
                    var merchandiseTypeEntity = new MerchandiseType()
                    {
                        MerchandiseId = Guid.NewGuid().ToString(),
                        Type = command.MerchandiseType.Type,
                        Name = command.MerchandiseType.Name,
                        CalculationUnit = command.MerchandiseType.CalculationUnit,
                        Description = command.MerchandiseType.Description,
                        CreatedDate = System.DateTime.Now,
                        LastModifiedDate = System.DateTime.Now
                    };
                    uow.Repository<MerchandiseType>().Add(merchandiseTypeEntity);
                    uow.SubmitChanges();

                    //Insert new Activity
                    var activity = new Activity();
                    activity.Source = "Loại Hàng";
                    activity.Source_Id = merchandiseTypeEntity.MerchandiseId;
                    activity.Action = "Tạo";
                    activity.Current_value = merchandiseTypeEntity.Name;
                    activity.CreatedDate = merchandiseTypeEntity.CreatedDate;
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
