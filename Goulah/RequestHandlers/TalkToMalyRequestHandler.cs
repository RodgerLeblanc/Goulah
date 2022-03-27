using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class TalkToMalyRequestHandler : BaseRequestHandler<IntentRequest>
    {
        public TalkToMalyRequestHandler(IntentRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            await Task.CompletedTask;

            IOutputSpeech speechResponse = new SsmlOutputSpeech 
            { 
                Ssml = @"
<speak>
    <amazon:effect name=""whispered"">Maly</amazon:effect>
    <break time=""500ms""/>
    <amazon:effect name=""whispered"">Maly</amazon:effect>
    <break time=""2s""/>
    <amazon:effect name=""whispered"">Ta yeule</amazon:effect>
</speak>"};

            SkillResponse response = ResponseBuilder.Tell(speechResponse);

            return new OkObjectResult(response);
        }
    }
}
