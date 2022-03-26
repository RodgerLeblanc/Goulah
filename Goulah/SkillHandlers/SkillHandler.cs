using Alexa.NET.Request.Type;
using GoulahAlexaSkill.RequestHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.SkillHandlers
{
    public class SkillHandler : ISkillHandler
    {
        private IRequestHandler _requestHandler;

        public SkillHandler(Request request)
        {
            _requestHandler = RequestHandlerHelper.GetFromRequest(request);
        }

        public Task<IActionResult> GetResultAsync()
        {
            return _requestHandler.GetResultAsync();
        }
    }
}
