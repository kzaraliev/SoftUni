using HouseRentingSystem.Core.Constants;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSysterm.Attributes;
using HouseRentingSysterm.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSysterm.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        [HttpGet]
        [NotAnAgent]
        public IActionResult Become()
        {

            var model = new BecomeAgentFormModel();
            return View(model);
        }

        [HttpPost]
        [NotAnAgent]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            if(await agentService.UserWithPhoneExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), MessageConstants.PhoneExists);
            }

            if (await agentService.UserHasRentsAsync(User.Id()))
            {
                ModelState.AddModelError("Error", MessageConstants.HasRents);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await agentService.CreateAsync(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
