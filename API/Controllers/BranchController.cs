using Domain.Command;
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
    [RoutePrefix("NgocTrang/Api/Branch")]
    public class BranchController : BaseController
    {
        private IBranchService iBranchService;
        private IAccountService iAccountService;
        public BranchController(IBranchService _iBranchService, IAccountService _iAccountService)
        {
            iBranchService = _iBranchService;
            iAccountService = _iAccountService;
        }

        //GET: NgocTrang/Api/Branch/GetActive
        [Route("GetActiveBranches")]
        [HttpGet]
        public HttpResponseMessage GetActiveBranches(string token)
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
                var branchesList = iBranchService.GetActiveBranches();
                if(branchesList != null)
                {
                    if (branchesList.Count() > 0)
                    {
                        return GetResponseSuccess(branchesList, HttpStatusCode.OK);
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

        //GET: NgocTrang/Api/Branch/GetAll
        [Route("GetAllBranches")]
        [HttpGet]
        public HttpResponseMessage GetAllBranches(string token)
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
                var branchesList = iBranchService.GetAllBranches();
                if (branchesList != null)
                {
                    if (branchesList.Count() > 0)
                    {
                        return GetResponseSuccess(branchesList, HttpStatusCode.OK);
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

        //POST: NgocTrang/Api/Branch/Add
        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Add(BranchVM branchVM,string token)
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
                branchVM.UserId = tokenizedUserId;
                iBranchService.AddBranch(branchVM);
                return PostResponseSuccess(HttpStatusCode.OK,SucessMessageConstant.RequestHandleSuccessful);
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

        //POST: NgocTrang/Api/Branch/UpdateName/1/ABC
        [Route("UpdateName/{id}/{name}")]
        [HttpPost]
        public HttpResponseMessage UpdateBranchName(string id, string name,string token)
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
                iBranchService.UpdateBranchName(id, name , tokenizedUserId);
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

        //POST: NgocTrang/Api/Branch/UpdateAddress/1/address
        [Route("UpdateAddress/{id}/{address}")]
        [HttpPost]
        public HttpResponseMessage UpdateBranchAddress(string id, string address, string token)
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
                iBranchService.UpdateBranchAddress(id, address, tokenizedUserId);
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

        //POST: NgocTrang/Api/Branch/UpdatePhone/1/012345
        [Route("UpdatePhone/{id}/{phone}")]
        [HttpPost]
        public HttpResponseMessage UpdateBranchPhone(string id, string phone,string token)
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
                iBranchService.UpdateBranchName(id, phone, tokenizedUserId);
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

        //POST: NgocTrang/Api/Branch/UpdateEmail/1/abc@gxyz.com
        [Route("UpdateEmail/{id}/{email}")]
        [HttpPost]
        public HttpResponseMessage UpdateBranchEmail(string id, string email, string token)
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
                iBranchService.UpdateBranchName(id, email, tokenizedUserId);
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

        //POST: NgocTrang/Api/Branch/UpdateCode
        [Route("UpdateCode/{id}/{branchCode}")]
        [HttpPost]
        public HttpResponseMessage UpdateBranchCode(string id, string branchCode, string token)
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
                iBranchService.UpdateBranchCode(id, branchCode, tokenizedUserId);
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

        //POST: NgocTrang/Api/Branch/Revoke
        [Route("Revoke/{id}")]
        [HttpPost]
        public HttpResponseMessage ActiveBranch(string id, string token)
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
                iBranchService.ActiveBranch(id, tokenizedUserId);
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

        //POST: NgocTrang/Api/Branch/Delete
        [Route("Delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteBranch(string id,string token)
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
                iBranchService.InactiveBranch(id, tokenizedUserId);
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
