using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.SkillHandlers
{
    public interface ISkillHandler
    {
        Task<IActionResult> GetResultAsync();
    }
}
