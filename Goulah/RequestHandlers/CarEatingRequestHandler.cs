using Alexa.NET.Request.Type;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class CarEatingRequestHandler : BaseRequestHandler<IntentRequest, CarEatingResponses>
    {
        public CarEatingRequestHandler(IntentRequest request) : base(request)
        {
        }
    }
}
