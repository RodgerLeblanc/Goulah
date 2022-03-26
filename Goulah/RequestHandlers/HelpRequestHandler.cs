using Alexa.NET.Request.Type;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class HelpRequestHandler : BaseRequestHandler<IntentRequest, HelpResponses>
    {
        public HelpRequestHandler(IntentRequest request) : base(request)
        {
        }
    }
}
