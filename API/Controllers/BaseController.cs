using Domain.Constant;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
                                                                
namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
        protected HttpResponseMessage GetResponseSuccess(object obj, HttpStatusCode httpCode)
        {
            HttpResponseMessage response = Request.CreateResponse();
            response.StatusCode = httpCode;
            if (HttpStatusCode.OK.Equals(httpCode))
            {
                response.Content = new StringContent(JsonConvert.SerializeObject(obj));
            }
            return response;
        }
        protected HttpResponseMessage GetResponseFail(HttpStatusCode httpCode, string errMassage )
        {
            HttpResponseMessage response = Request.CreateResponse();
            response.StatusCode = httpCode;
            if (!HttpStatusCode.OK.Equals(httpCode))
            {
                response.Content = new StringContent(errMassage);
            }
            return response;
        }
    
        protected HttpResponseMessage PostResponseSuccess(object obj, HttpStatusCode httpCode)
        {
            HttpResponseMessage response = Request.CreateResponse();
            response.StatusCode = httpCode;
            if (HttpStatusCode.OK.Equals(httpCode))
            {
                response.Content = new StringContent(JsonConvert.SerializeObject(obj));
            }
            return response;
        }
        protected HttpResponseMessage PostResponseSuccess(HttpStatusCode httpCode,string message)
        {
            HttpResponseMessage response = Request.CreateResponse();
            response.StatusCode = httpCode;
            if (HttpStatusCode.OK.Equals(httpCode))
            {
                response.Content = new StringContent(message);
            }
            return response;
        }

        protected HttpResponseMessage PostResponseFail(HttpStatusCode httpCode, string errMessage)
        {
            HttpResponseMessage response = Request.CreateResponse();
            response.StatusCode = httpCode;
            if (!HttpStatusCode.OK.Equals(httpCode))
            {
                response.Content = new StringContent(errMessage);
            }
            return response;
        }
    }
}