using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using GoulahAlexaSkill.ResponseTexts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class LaunchRequestHandler : BaseRequestHandler<LaunchRequest>
    {
        public LaunchRequestHandler(LaunchRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            await Task.CompletedTask;

            string speechText = RandomResponseExtractor.GetRandomResponse<LaunchResponses>();

            SkillResponse response = ResponseBuilder.Ask(speechText, RequestHandlerHelper.GetDefaultReprompt());
            return new OkObjectResult(response);
        }
    }
}
