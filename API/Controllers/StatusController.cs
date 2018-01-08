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
    [RoutePrefix("NgocTrang/Api/Status")]
    public class StatusController : BaseController
    {
        private IStatusService iStatusService;
        private IAccountService iAccountService;
        public StatusController(IStatusService _iStatusService, IAccountService _iAccountService)
        {
            iStatusService = _iStatusService;
            iAccountService = _iAccountService;
        }

        //GET: NgocTrang/Api/Status/GetAll
        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAllStatus(string token)
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
                var statusList = iStatusService.GetAllStatus();
                if (statusList != null)
                {
                    if (statusList.Count() > 0)
                    {
                        return GetResponseSuccess(statusList, HttpStatusCode.OK);
                    }
                    else
                    {
                        return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.EmptyListExceptionMassage);
                    }
                }
                return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.NullListExceptionMessage);
            }
            catch (Exception ex)
            {
                return GetResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //GET: NgocTrang/Api/Status/GetAll
        [Route("GetActive")]
        [HttpGet]
        public HttpResponseMessage GetActiveStatus(string token)
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
                var statusList = iStatusService.GetActiveStatus();
                if (statusList != null)
                {
                    if (statusList.Count() > 0)
                    {
                        return GetResponseSuccess(statusList, HttpStatusCode.OK);
                    }
                    else
                    {
                        return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.EmptyListExceptionMassage);
                    }
                }
                return GetResponseFail(HttpStatusCode.ExpectationFailed, ExceptionMessageConstant.NullListExceptionMessage);
            }
            catch (Exception ex)
            {
                return GetResponseFail(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //GET: NgocTrang/Api/Status/Add
        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Add(StatusVM statusVM, string token)
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
                statusVM.UserId = tokenizedUserId;
                iStatusService.AddStatus(statusVM);
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
