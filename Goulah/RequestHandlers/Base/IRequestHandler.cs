using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoulahAlexaSkill.RequestHandlers
{
    public interface IRequestHandler
    {
        Task<IActionResult> GetResultAsync();
    }
}
