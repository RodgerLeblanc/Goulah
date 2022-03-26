using Alexa.NET.Request.Type;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class LaunchRequestHandler : BaseRequestHandler<LaunchRequest, LaunchResponses>
    {
        public LaunchRequestHandler(LaunchRequest request) : base(request)
        {
        }
    }
}
