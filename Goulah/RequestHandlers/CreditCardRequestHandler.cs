using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using GoulahAlexaSkill.ResponseTexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public class CreditCardRequestHandler : BaseRequestHandler<IntentRequest, CreditCardResponses>
    {
        private static Random _random;

        public CreditCardRequestHandler(IntentRequest request) : base(request)
        {
        }

        public override async Task<IActionResult> GetResultAsync()
        {
            await Task.CompletedTask;

            string speechText = RandomResponseExtractor.GetRandomResponse<CreditCardResponses>();

            if (speechText.Contains("{0}"))
            {
                if (_random == null)
                {
                    _random = new Random(DateTime.Now.Millisecond);
                }

                SkillResponse response = ResponseBuilder.Tell(
                    string.Format(speechText, 
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10),

                        _random.Next(12),
                        _random.Next(DateTime.Now.Year + 1 - 2000, DateTime.Now.Year + 4 - 2000),

                        _random.Next(10),
                        _random.Next(10),
                        _random.Next(10)));

                return new OkObjectResult(response);
            }
            else
            {
                SkillResponse response = ResponseBuilder.Tell(speechText);

                return new OkObjectResult(response);
            }
        }
    }
}
