using Alexa.NET.Request.Type;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class CancelRequestHandler : BaseRequestHandler<IntentRequest, StopResponses>
    {
        public CancelRequestHandler(IntentRequest request) : base(request)
        {
        }
    }
}
