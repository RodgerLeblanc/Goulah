using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Alexa.NET.Request;
using GoulahAlexaSkill.RequestHandlers;
using GoulahAlexaSkill.SkillHandlers;
using Alexa.NET;
using Alexa.NET.Response;
using GoulahAlexaSkill.ResponseTexts;

namespace GoulahAlexaSkill
{
    public static class Goulah
    {
        [FunctionName(nameof(Goulah))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                SkillRequest skillRequest = await GetSkillRequestFromRequest(req);

                bool isValid = await RequestHandlerHelper.ValidateRequest(req, log, skillRequest);
                if (!isValid)
                {
                    return new BadRequestResult();
                }

                ISkillHandler skillHandler = new SkillHandler(skillRequest.Request);
                return await skillHandler.GetResultAsync();
            }
            catch (System.Exception e)
            {
                log.LogError(e.Message);

                string speechText = RandomResponseExtractor.GetRandomResponse<CouldNotProcessResponses>();

                SkillResponse response = ResponseBuilder.Ask(speechText, RequestHandlerHelper.GetDefaultReprompt());
                return new OkObjectResult(response);
            }
        }

        private static async Task<SkillRequest> GetSkillRequestFromRequest(HttpRequest req)
        {
            string json = await req.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SkillRequest>(json);
        }
    }
}
