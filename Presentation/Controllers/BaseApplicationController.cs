using GADistribuidora.Domain.Handlers.Interfaces;
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

        protected async Task<ActionResult> CustomResponse(HttpStatusCode code, object result = null)
        {
            var resultResponse = await GenerateResponseBasedInHttpStatusCode(code, result);
            return resultResponse;

        }

        private async Task<ActionResult> GenerateResponseBasedInHttpStatusCode(HttpStatusCode code, object result) 
        {
            ActionResult resultResponse = BadRequest(new { success = false });
            if (_notificationHandler.HasNotification())
            {
                if ((int)code >= 400 && (int)code < 500)
                {
                    var resultDataError = new
                    {
                        success = false,
                        errors = _notificationHandler.GetNotifications()
                    };
                    resultResponse = code switch
                    {
                        HttpStatusCode.BadRequest => BadRequest(resultDataError),
                        HttpStatusCode.Unauthorized => Unauthorized(resultDataError),
                        HttpStatusCode.Forbidden => Forbid(),
                        HttpStatusCode.NotFound => NotFound(resultDataError),
                        _ => BadRequest()
                    };
                }
            }
            else
            {
                if ((int)code >= 200 && (int)code < 300)
                {
                    var resultDataSuccess = new
                    {
                        success = true,
                        data = result
                    };
                    resultResponse = code switch
                    {
                        HttpStatusCode.OK => Ok(resultDataSuccess),
                        HttpStatusCode.Created => Created("", resultDataSuccess),
                        HttpStatusCode.NoContent => NoContent(),
                        _ => Ok()
                    };
                }
            }

            return resultResponse;
        }
    }
}
