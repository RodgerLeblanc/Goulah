namespace GoulahAlexaSkill.ResponseTexts
{
    public class RaiseResponses : BaseResponses
    {
        public RaiseResponses()
        {
            Add("Y'en ai pas question.");
            Add("J'ai pas le temps là, peux-tu m'en reparler l'an prochain?");
            Add("Douze dollars de l'heure, c'est pas assez?");
        }
    }

    public class RaiseWithAmountResponses : BaseResponses
    {
        public RaiseWithAmountResponses()
        {
            Add("{0} de plus? Y'en ai pas question.");
            Add("{0} de plus? J'ai pas le temps là, peux-tu m'en reparler l'an prochain?");
            Add("{0} de plus? Douze dollars de l'heure, c'est pas assez?");
        }
    }
}
