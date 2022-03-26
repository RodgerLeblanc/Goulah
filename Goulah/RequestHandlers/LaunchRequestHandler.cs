using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using GoulahAlexaSkill.ResponseTexts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class LaunchRequestHandler : BaseRequestHandler<LaunchRequest, LaunchResponses>
    {
        public LaunchRequestHandler(LaunchRequest request) : base(request)
        {
        }
    }
}
