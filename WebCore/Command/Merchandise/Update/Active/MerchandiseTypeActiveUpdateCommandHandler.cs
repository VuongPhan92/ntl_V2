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
    public class MerchandiseTypeActiveUpdateCommandHandler : ICommandHandler<MerchandiseTypeActiveUpdateCommand>
    {
        private readonly IActivityService iActivityServices;
        public MerchandiseTypeActiveUpdateCommandHandler(IActivityService _iActivityServices)
        {
            iActivityServices = _iActivityServices;
        }
        public void Handle(MerchandiseTypeActiveUpdateCommand command)
        {
            using (var uow = new UnitOfWork<EF>())
            {
                try
                {
                    //update
                    var merchandiseTypeEntity = uow.Repository<MerchandiseType>().GetById(p => p.MerchandiseId.Equals(command.MerchandiseTypeId));
                    var previousVal = merchandiseTypeEntity.DeletedDate;
                    merchandiseTypeEntity.LastModifiedDate = System.DateTime.Now;
                    merchandiseTypeEntity.DeletedDate = null;
                    uow.Repository<MerchandiseType>().Update(merchandiseTypeEntity);
                    uow.SubmitChanges();
                    //Insert new Activity
                    var activity = new Activity()
                    {
                        Source = "Loại hàng",
                        Source_Id = merchandiseTypeEntity.MerchandiseId,
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
