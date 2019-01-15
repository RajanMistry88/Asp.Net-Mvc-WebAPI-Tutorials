using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MvcTutorialWebAPI.Helper
{
    public static class ResponseHelper
    {
        public static HttpResponseMessage GenerateResponse(this ApiController controller, bool status, HttpStatusCode statusCode, dynamic value, bool isLookUp = true)
        {
            if (isLookUp)
            {
                var retVal = new { status, statusCode, response = value };
                return controller.Request.CreateResponse(statusCode, retVal);
            }
            else
            {
                var retVal = new { status, statusCode, lookUp = false, response = value };
                return controller.Request.CreateResponse(statusCode, retVal);
            }
        }

        public static HttpResponseMessage GenerateErrorResponse(this ApiController controller, Exception ex)
        {
            return controller.GenerateErrorResponse(HttpStatusCode.InternalServerError, ex);
        }

        public static HttpResponseMessage GenerateErrorResponse(this ApiController controller, HttpStatusCode statusCode, Exception ex)
        {
            var errorMessage = Constants.ERRORMSG + ex.Message;
            return controller.Request.CreateErrorResponse(statusCode, ex.InnerException == null ? errorMessage : errorMessage + Constants.INNEREXCEPTION + ex.InnerException.Message);
        }

    }
}