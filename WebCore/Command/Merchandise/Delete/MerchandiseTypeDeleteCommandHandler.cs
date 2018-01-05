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
    class MerchandiseTypeDeleteCommandHandler : ICommandHandler<MerchandiseTypeDeleteCommand>
    {
        private readonly IActivityService iActivityServices;
        public MerchandiseTypeDeleteCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }
        public void Handle(MerchandiseTypeDeleteCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //delete
                    var merchandiseTypeEntity = uow.Repository<MerchandiseType>().GetById(p=>p.MerchandiseId.Equals(command.MerchandiseId) && !p.DeletedDate.HasValue);
                    merchandiseTypeEntity.DeletedDate = System.DateTime.Now;
                    merchandiseTypeEntity.LastModifiedDate = System.DateTime.Now;
                    uow.Repository<MerchandiseType>().Update(merchandiseTypeEntity);
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
