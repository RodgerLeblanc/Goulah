using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using GoulahAlexaSkill.ResponseTexts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public abstract class BaseAudioRequestHandler<TRequest> : BaseRequestHandler<TRequest>
        where TRequest : Request
    {
        //This audio feed is not valid because it is not https.
        //https://developer.amazon.com/en-US/docs/alexa/custom-skills/audioplayer-interface-reference.html#audio-stream-requirements
        protected const string AudioUrl = "http://13598.cloudrad.io:9144/live";
        protected const string Token = "0436EEF3-7571-489F-A3C2-3F6F062E9DB9";

        public BaseAudioRequestHandler(TRequest request) : base(request)
        {
        }
    }
}
