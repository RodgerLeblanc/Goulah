using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using GoulahAlexaSkill.ResponseTexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class RaiseIntentHandler : BaseRequestHandler<IntentRequest, RaiseResponses>
    {
        public RaiseIntentHandler(IntentRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            if (Request is IntentRequest intentRequest)
            {
                if (intentRequest.Intent.Slots?.Values.FirstOrDefault() is Slot slot)
                {
                    string speechText = RandomResponseExtractor.GetRandomResponse<RaiseWithAmountResponses>();
                    SkillResponse response = ResponseBuilder.Tell(string.Format(speechText, slot.Value));

                    return new OkObjectResult(response);
                }
            }

            return await base.GetResultAsync();
        }
    }
}
