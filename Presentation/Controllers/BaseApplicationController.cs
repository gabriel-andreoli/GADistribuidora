using GADistribuidora.Domain.Handlers.Interfaces;
using GADistribuidora.Presentation.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GADistribuidora.Presentation.Controllers
{
    public class BaseApplicationController : ControllerBase
    {
        private readonly INotificationHandler _notificationHandler;
        public BaseApplicationController(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        protected async Task<ActionResult> CustomResponse<T>(HttpStatusCode code, T result) where T : class
        {
            ActionResult resultResponse;
            if (_notificationHandler.HasNotification())
                resultResponse = await GenerateErrorResponse(code);
            else
                resultResponse = await GenerateSuccessResponse(code, result);

            return resultResponse;
        }

        private async Task<ActionResult> GenerateSuccessResponse<T>(HttpStatusCode code, T result) where T : class
        {
            var responseDTO = new ResponseDTO<T>(true);
            responseDTO.AddData(result);

            ActionResult resultResponse = Ok(responseDTO);
            if ((int)code >= 200 && (int)code < 300)
            {
                resultResponse = code switch
                {
                    HttpStatusCode.Created => Created("", responseDTO),
                    HttpStatusCode.NoContent => NoContent(),
                    _ => Ok(responseDTO)
                };
            }
            return resultResponse;
        }

        private async Task<ActionResult> GenerateErrorResponse(HttpStatusCode code)
        {
            var responseDTO = new ResponseDTO<string>(false);
            _notificationHandler.GetNotifications().ForEach(x => responseDTO.AddError(x));

            ActionResult resultResponse = BadRequest(responseDTO);
            if ((int)code >= 400 && (int)code < 500)
            {
                resultResponse = code switch
                {
                    HttpStatusCode.Unauthorized => Unauthorized(responseDTO),
                    HttpStatusCode.Forbidden => Forbid(),
                    HttpStatusCode.NotFound => NotFound(responseDTO),
                    _ => BadRequest(responseDTO)
                };
            }
            return resultResponse;
        }

        protected void AddNotification(string message) => _notificationHandler.AddNotification(message);
    }
}
