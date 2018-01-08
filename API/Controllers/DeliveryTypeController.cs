using Domain.Constant;
using Domain.IServices;
using Domain.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("NgocTrang/Api/DeliveryType")]
    public class DeliveryTypeController : BaseController
    {
        private IDeliveryTypeService iDeliveryTypeService;
        private IAccountService iAccountService;

        public DeliveryTypeController(IDeliveryTypeService _iDeliveryTypeService, IAccountService _iAccountService)
        {
            iDeliveryTypeService = _iDeliveryTypeService;
            iAccountService = _iAccountService;
        }

        //GET: NgocTrang/Api/DeliveryType/GetAll
        [Route("GetActive")]
        [HttpGet]
        public HttpResponseMessage GetActiveDeliveryTypes(string token)
        {
            try
            {
                //check token info
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
                //proceed request
                var deliveryTypeList = iDeliveryTypeService.GetActiveDeliveryTypes();
                if(deliveryTypeList!=null)
                {
                    if (deliveryTypeList.Count() > 0)
                    {
                        return GetResponseSuccess(deliveryTypeList, HttpStatusCode.OK);
                    }
                    else
                    {
                        return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.EmptyListExceptionMassage);
                    }
                }
                return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.NullListExceptionMessage);
            }
            catch (NullReferenceException)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.RequestNullExceptionMassge);
            }
            catch (Exception ex)
            {
                return GetResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }

        }

        //GET: NgocTrang/Api/DeliveryType/GetAll
        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAllDeliveryType(string token)
        {
            try
            {
                //check token info
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
                //proceed request
                var deliveryTypes = iDeliveryTypeService.GetAllDeliveryTypes();
                if (deliveryTypes.Count() >0)
                {
                    return GetResponseSuccess(deliveryTypes, HttpStatusCode.OK);
                }
                else
                {
                    return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.EmptyListExceptionMassage);
                }
            }
            catch (NullReferenceException)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.RequestNullExceptionMassge);
            }
            catch (Exception ex)
            {
                return GetResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }

        }

        //POST: NgocTrang/Api/DeliveryType/Add
        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Add(DeliveryTypeVM deliveryTypeVM, string token)
        {
            try
            {
                //check token info
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
                //proceed request
                var tokenizedUserId = iAccountService.GetUserIdByToken(token);
                deliveryTypeVM.UserId = tokenizedUserId;
                iDeliveryTypeService.AddDeliveryType(deliveryTypeVM);
                return PostResponseSuccess(HttpStatusCode.OK, SucessMessageConstant.RequestHandleSuccessful);
            }
            catch (NullReferenceException)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.RequestNullExceptionMassge);
            }
            catch (Exception ex)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //POST: NgocTrang/Api/DeliveryType/UpdateValue
        [Route("UpdateValue/{id}/{value}")]
        [HttpPost]
        public HttpResponseMessage UpdateDeliveryTypeValue(string id, string value, string token)
        {
            try
            {
                //check token info 
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
                //proceed request
                var tokenizedUserId = iAccountService.GetUserIdByToken(token);
                iDeliveryTypeService.UpdateDeliveryTypeName(id, value, tokenizedUserId);
                return PostResponseSuccess(HttpStatusCode.OK, SucessMessageConstant.RequestHandleSuccessful);
            }
            catch (NullReferenceException)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.RequestNullExceptionMassge);
            }
            catch (Exception ex)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //POST: NgocTrang/Api/DeliveryType/UpdateName
        [Route("UpdateName/{id}/{name}")]
        [HttpPost]
        public HttpResponseMessage UpdateDeliveryTypeName(string id, string name, string token)
        {
            try
            {
                //check token info
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
                //proceed request
                var tokenizedUserId = iAccountService.GetUserIdByToken(token);
                iDeliveryTypeService.UpdateDeliveryTypeName(id, name, tokenizedUserId);
                return PostResponseSuccess(HttpStatusCode.OK, SucessMessageConstant.RequestHandleSuccessful);
            }
            catch (NullReferenceException)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.RequestNullExceptionMassge);
            }
            catch (Exception ex)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //POST: NgocTrang/Api/DeliveryType/UpdateDescription
        [Route("UpdateDescription/{id}/{description}")]
        [HttpPost]
        public HttpResponseMessage UpdateDeliveryTypeDescription(string id, string description, string token)
        {
            try
            {
                //check token info
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
                //proceed request
                var tokenizedUserId = iAccountService.GetUserIdByToken(token);
                iDeliveryTypeService.UpdateDeliveryTypeName(id, description, tokenizedUserId);
                return PostResponseSuccess(HttpStatusCode.OK, SucessMessageConstant.RequestHandleSuccessful);
            }
            catch (NullReferenceException)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.RequestNullExceptionMassge);
            }
            catch (Exception ex)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //POST: NgocTrang/Api/DeliveryType/Revoke
        [Route("Revoke/{id}")]
        [HttpPost]
        public HttpResponseMessage ActiveDeliveryType(string id, string token)
        {
            try
            {
                //check token info
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
                //proceed request
                var tokenizedUserId = iAccountService.GetUserIdByToken(token);
                iDeliveryTypeService.ActiveDeliveryType(id, tokenizedUserId);
                return PostResponseSuccess(HttpStatusCode.OK, SucessMessageConstant.RequestHandleSuccessful);
            }
            catch (NullReferenceException)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.RequestNullExceptionMassge);
            }
            catch (Exception ex)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //POST: NgocTrang/Api/DeliveryType/Delete
        [Route("Delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteDeliveryType(string id, string token)
        {
            try
            {
                //check token info
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
                //proceed request
                var tokenizedUserId = iAccountService.GetUserIdByToken(token);
                iDeliveryTypeService.InactiveDeliveryType(id, tokenizedUserId);
                return PostResponseSuccess(HttpStatusCode.OK, SucessMessageConstant.RequestHandleSuccessful);
            }
            catch (NullReferenceException)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.RequestNullExceptionMassge);
            }
            catch (Exception ex)
            {
                return PostResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }
    }
}
