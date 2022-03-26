using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using GoulahAlexaSkill.ResponseTexts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public abstract class BaseRequestHandler<TRequest, TResponses> : BaseRequestHandler<TRequest>
        where TRequest : Request
        where TResponses : BaseResponses, new()
    {
        public BaseRequestHandler(TRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            await Task.CompletedTask;

            string speechText = RandomResponseExtractor.GetRandomResponse<TResponses>();
            SkillResponse response = ResponseBuilder.Tell(speechText);

            return new OkObjectResult(response);
        }
    }

    public abstract class BaseRequestHandler<TRequest> : IRequestHandler
        where TRequest : Request
    {
        public BaseRequestHandler(TRequest request)
        {
            Request = request;
        }

        protected TRequest Request { get; }

        public abstract Task<IActionResult> GetResultAsync();
    }
}
