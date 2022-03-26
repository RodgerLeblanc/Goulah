using Alexa.NET.Request.Type;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class StopRequestHandler : BaseRequestHandler<IntentRequest, StopResponses>
    {
        public StopRequestHandler(IntentRequest request) : base(request)
        {
        }
    }
}
