﻿using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using GoulahAlexaSkill.ResponseTexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public static class RequestHandlerHelper
    {
        private const string CarEatingIntentName = "CarEatingIntent";
        private const string ComeHereIntentName = "ComeHereIntent";
        private const string CreditCardIntentName = "CreditCardIntent";
        private const string MostBeautifulIntentName = "MostBeautifulIntent";
        private const string RaiseIntentName = "RaiseIntent";
        private const string TalkToMalyIntentName = "TalkToMalyIntent";
        private const string CancelIntentName = "AMAZON.CancelIntent";
        private const string HelpIntentName = "AMAZON.HelpIntent";
        private const string StopIntentName = "AMAZON.StopIntent";
        private const string FallbackIntentName = "AMAZON.FallbackIntent";

        public static IRequestHandler GetFromRequest(Request request)
        {
            switch (request)
            {
                case LaunchRequest launchRequest:
                    return new LaunchRequestHandler(launchRequest);

                case IntentRequest intentRequest:
                    return GetRequestHandlerFromIntentRequest(intentRequest);
            }

            return null;
        }

        private static IRequestHandler GetRequestHandlerFromIntentRequest(IntentRequest intentRequest)
        {
            switch (intentRequest.Intent.Name)
            {
                case CarEatingIntentName:
                    return new CarEatingRequestHandler(intentRequest);

                case ComeHereIntentName:
                    return new ComeHereRequestHandler(intentRequest);

                case CreditCardIntentName:
                    return new CreditCardRequestHandler(intentRequest);

                case MostBeautifulIntentName:
                    return new MostBeautifulRequestHandler(intentRequest);

                case RaiseIntentName:
                    return new RaiseIntentHandler(intentRequest);

                case TalkToMalyIntentName:
                    return new TalkToMalyRequestHandler(intentRequest);

                case CancelIntentName:
                    return new CancelRequestHandler(intentRequest);

                case HelpIntentName:
                case FallbackIntentName:
                    return new HelpRequestHandler(intentRequest);

                case StopIntentName:
                    return new StopRequestHandler(intentRequest);

                default:
                    throw new ArgumentException("Could not find a matching handler for the IntentRequest Intent");
            }
        }

        public static Reprompt GetDefaultReprompt()
        {
            string repromptText = RandomResponseExtractor.GetRandomResponse<HelpResponses>();
            return new Reprompt(repromptText);
        }

        public static async Task<bool> ValidateRequest(HttpRequest request, ILogger log, SkillRequest skillRequest)
        {
            request.Headers.TryGetValue("SignatureCertChainUrl", out var signatureChainUrl);
            if (string.IsNullOrWhiteSpace(signatureChainUrl))
            {
                log.LogError("Validation failed. Empty SignatureCertChainUrl header");
                return false;
            }

            Uri certUrl;
            try
            {
                certUrl = new Uri(signatureChainUrl);
            }
            catch
            {
                log.LogError($"Validation failed. SignatureChainUrl not valid: {signatureChainUrl}");
                return false;
            }

            request.Headers.TryGetValue("Signature", out var signature);
            if (string.IsNullOrWhiteSpace(signature))
            {
                log.LogError("Validation failed - Empty Signature header");
                return false;
            }

            request.Body.Position = 0;
            var body = await request.ReadAsStringAsync();
            request.Body.Position = 0;

            if (string.IsNullOrWhiteSpace(body))
            {
                log.LogError("Validation failed - the JSON is empty");
                return false;
            }

#if DEBUG
            return true;
#else
            bool isTimestampValid = RequestVerification.RequestTimestampWithinTolerance(skillRequest);
            bool valid = await RequestVerification.Verify(signature, certUrl, body);

            if (!valid || !isTimestampValid)
            {
                log.LogError("Validation failed - RequestVerification failed");
                return false;
            }
            else
            {
                return true;
            }
#endif
        }
    }
}
