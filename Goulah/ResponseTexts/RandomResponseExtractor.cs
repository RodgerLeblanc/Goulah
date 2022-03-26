using System;
using System.Linq;

namespace GoulahAlexaSkill.ResponseTexts
{
    public static class RandomResponseExtractor
    {
        private static Random _random;

        public static string GetRandomResponse<TResponses>()
            where TResponses : BaseResponses, new()
        {
            var responses = new TResponses();

            if (!responses.Any())
            {
                throw new InvalidOperationException("Responses should not be empty.");
            }

            if (_random == null)
            {
                _random = new Random(DateTime.Now.Millisecond);
            }

            return responses.ElementAt(_random.Next(responses.Count()));
        }
    }
}
