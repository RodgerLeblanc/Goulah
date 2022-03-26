using Alexa.NET.Request.Type;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class ComeHereRequestHandler : BaseRequestHandler<IntentRequest, ComeHereResponses>
    {
        public ComeHereRequestHandler(IntentRequest request) : base(request)
        {
        }
    }
}
