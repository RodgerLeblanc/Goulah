using Alexa.NET.Request.Type;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class RaiseIntentHandler : BaseRequestHandler<IntentRequest, RaiseResponses>
    {
        public RaiseIntentHandler(IntentRequest request) : base(request)
        {
        }
    }
}
