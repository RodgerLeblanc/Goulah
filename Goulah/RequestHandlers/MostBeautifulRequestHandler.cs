using Alexa.NET.Request.Type;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class MostBeautifulRequestHandler : BaseRequestHandler<IntentRequest, MostBeautifulResponses>
    {
        public MostBeautifulRequestHandler(IntentRequest request) : base(request)
        {
        }
    }
}
