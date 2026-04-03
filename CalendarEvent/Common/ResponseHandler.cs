using FluentValidation.Results;
using System.Net;

namespace CalendarEvent.Common
{
    public static class ResponseHandler
    {
       
        public static APIResponse GetValidationErrorResponse(ValidationResult validationResult)
        {
            IDictionary<string,string> errors=new Dictionary<string,string>();
            foreach (var error in validationResult.Errors)
            {
                errors[error.PropertyName]=error.ErrorMessage;
            }
            return new APIResponse(false,HttpStatusCode.BadRequest,Message.Error);
        }

        public static APIResponse GetValidationErrorResponse(string validationResult)
        {
            return new APIResponse(false,HttpStatusCode.BadRequest,Message.Error);
        }
        public static APIResponse GetValidationErrorResponse(List<ValidationResult> validationResults)
        {
            var errors = validationResults.SelectMany(x => x.Errors).ToList();
            return new APIResponse(false,HttpStatusCode.BadRequest,errors,Message.Error);
        }
        public static APIResponse GetSuccessResponse(dynamic data,string message)
        {
            return new APIResponse(true,HttpStatusCode.OK,data,message);
        }
        public static APIResponse GetBadRequestResponse(string message)
        {
            return new APIResponse(false,HttpStatusCode.BadRequest,message);
        }
        public static APIResponse GetNotFoundResponse(string message)
        {
            return new APIResponse(false,HttpStatusCode.NotFound,message);
        }
        public static APIResponse GetUnAuthorizeResponse(string message)
        {
            return new APIResponse(false,HttpStatusCode.Unauthorized,message);
        }
    }
}
