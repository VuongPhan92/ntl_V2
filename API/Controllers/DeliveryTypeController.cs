using Domain.Constant;
using Domain.IServices;
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
        private IDeliveryTypeService iDeliveryTypeServices;
        private IAccountService iAccountService;

        public DeliveryTypeController(IDeliveryTypeService _iDeliveryTypeServices, IAccountService _iAccountService)
        {
            iDeliveryTypeServices = _iDeliveryTypeServices;
            iAccountService = _iAccountService;
        }

        //GET: NgocTrang/Api/DeliveryType/GetAll
        [Route("GetActive")]
        [HttpGet]
        public HttpResponseMessage GetActiveDeliveryTypes(string token)
        {
            try
            {
                var deliveryTypeList = iDeliveryTypeServices.GetActiveDeliveryTypes();
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }

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
                var deliveryTypes = iDeliveryTypeServices.GetAllDeliveryTypes();
                var isAllow = iAccountService.IsTokenAvailable(token);
                if (!isAllow)
                {
                    return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.TokenNotAvailable);
                }
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
    }
}
