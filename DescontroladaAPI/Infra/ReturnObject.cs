using DescontroladaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DescontroladaAPI.Infra
{
    public static class ReturnObject
    {
        public static ActionResult Return(bool success = true, string? message = null, string? internalMessage = null, object? obj = null)
        {
            return Return(success, message, internalMessage, obj, 200);
        }

        public static ActionResult InvalidModelStateResponse(bool success, string message, string? internalMessage = null, object? obj = null)
        {
            var statusCode = 400;

            return Return(success, message, internalMessage, obj, statusCode);
        }

        public static ActionResult Return(bool success, string? message, string? internalMessage, object? obj, int statusCode)
        {
            var resultModel = new ReturnObjectModel() { ErrorResponse = new ErrorResponseModel[1] };

            if (success)
            {
                resultModel.Status = 1;
                resultModel.Object = obj ?? true;
            }
            else
            {
                resultModel = BuildErrorResponseObject(resultModel, message, internalMessage);
            }

            return new ObjectResult(resultModel) { StatusCode = statusCode };
        }

        public static ReturnObjectModel BuildErrorResponseObject(ReturnObjectModel resultModel, string? message, string? internalMessage)
        {
            resultModel.Status = 0;
            resultModel.ErrorResponse[0] = new ErrorResponseModel()
            {
                Message = message ?? "An error has occurred. Please contact the administrator.",
                InternalMessage = internalMessage,
            };

            return resultModel;
        }
    }
}
