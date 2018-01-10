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
    [RoutePrefix("NgocTrang/Api/MerchandiseType")]
    public class MerchandiseTypeController : BaseController
    {
        private IMerchandiseTypeService iMerchandiseTypeService;
        private IAccountService iAccountService;

        public MerchandiseTypeController(IMerchandiseTypeService _iMerchandiseTypeService, IAccountService _iAccountService)
        {
            iMerchandiseTypeService = _iMerchandiseTypeService;
            iAccountService = _iAccountService;
        }

        //GET: NgocTrang/Api/MerchandiseType/GetActive
        [Route("GetActive")]
        [HttpGet]
        public HttpResponseMessage GetActiveMerchandise(string token)
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
                var merchandiseTypeList = iMerchandiseTypeService.GetActiveMerchandiseTypes();

                if (merchandiseTypeList != null)
                {
                    if (merchandiseTypeList.Count() > 0)
                    {
                        return GetResponseSuccess(merchandiseTypeList, HttpStatusCode.OK);
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

        //GET: NgocTrang/Api/MerchandiseType/GetAll
        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAllMerchandise(string token)
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
                var merchandiseTypeList = iMerchandiseTypeService.GetAllMerchandiseTypes();
                
                if (merchandiseTypeList != null)
                {
                    if (merchandiseTypeList.Count() > 0)
                    {
                        return GetResponseSuccess(merchandiseTypeList, HttpStatusCode.OK);
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

        //POST: NgocTrang/Api/MerchandiseType/Add
        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Add(MerchandiseTypeVM merchandiseTypeVM,string token)
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
                merchandiseTypeVM.UserId = tokenizedUserId;
                iMerchandiseTypeService.AddMerchandise(merchandiseTypeVM);
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

        //POST: NgocTrang/Api/MerchandiseType/UpdateName
        [Route("UpdateName/{id}/{name}")]
        [HttpPost]
        public HttpResponseMessage UpdateMerchandiseTypeName(string id,string name, string token)
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
                iMerchandiseTypeService.UpdateMerchandiseTypeName(id,name,tokenizedUserId);
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

        //POST: NgocTrang/Api/MerchandiseType/UpdateUnit
        [Route("UpdateUnit/{id}/{unit}")]
        [HttpPost]
        public HttpResponseMessage UpdateMerchandiseTypeUnit(string id, string unit, string token)
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
                iMerchandiseTypeService.UpdateMerchandiseTypeUnit(id, unit, tokenizedUserId);
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

        //POST: NgocTrang/Api/MerchandiseType/UpdateType
        [Route("UpdateType/{id}/{type}")]
        [HttpPost]
        public HttpResponseMessage UpdateMerchandiseTypeType(string id, string type, string token)
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
                iMerchandiseTypeService.UpdateMerchandiseTypeType(id, type, tokenizedUserId);
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

        //POST: NgocTrang/Api/MerchandiseType/UpdateDescription
        [Route("UpdateDescription/{id}/{description}")]
        [HttpPost]
        public HttpResponseMessage UpdateMerchandiseTypeDescription(string id, string description, string token) 
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
                iMerchandiseTypeService.UpdateMerchandiseTypeDescription(id, description, tokenizedUserId);
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

        //POST: NgocTrang/Api/MerchandiseType/Revoke/id
        [Route("Revoke/{id}")]
        [HttpPost]
        public HttpResponseMessage ActiveMerchandiseType(string id, string token)
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
                iMerchandiseTypeService.ActiveMerchandiseType(id, tokenizedUserId);
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

        //POST: NgocTrang/Api/MerchandiseType/Delete/id
        [Route("Delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteMerchandiseType(string id,string token)
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
                iMerchandiseTypeService.InactiveMerchandise(id, tokenizedUserId);
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
