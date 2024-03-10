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

        protected async Task<ActionResult<T>> CustomResponse<T>(HttpStatusCode code, T result) where T : class
        {
            ActionResult<T> resultResponse;
            if (_notificationHandler.HasNotification())
                resultResponse = await GenerateErrorResponse<T>(code);
            else
                resultResponse = await GenerateSuccessResponse<T>(code, result);

            return resultResponse;
        }

        private async Task<ActionResult<T>> GenerateSuccessResponse<T>(HttpStatusCode code, T result) where T : class
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
                    _ => Ok()
                };
            }
            return resultResponse;
        }

        private async Task<ActionResult<T>> GenerateErrorResponse<T>(HttpStatusCode code) where T : class
        {
            var responseDTO = new ResponseDTO<T>(false);
            _notificationHandler.GetNotifications().ForEach(x => responseDTO.AddError(x));

            ActionResult resultResponse = BadRequest(responseDTO);
            if ((int)code >= 400 && (int)code < 500)
            {
                resultResponse = code switch
                {
                    HttpStatusCode.Unauthorized => Unauthorized(responseDTO),
                    HttpStatusCode.Forbidden => Forbid(),
                    HttpStatusCode.NotFound => NotFound(responseDTO),
                    _ => BadRequest()
                };
            }
            return resultResponse;
        }
    }
}
