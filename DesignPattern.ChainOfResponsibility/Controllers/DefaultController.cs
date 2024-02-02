using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasurer();
            Employee managerAsistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee regionalDirector = new RegionalDirector();

            treasurer.SetNextAprover(managerAsistant);
            managerAsistant.SetNextAprover(manager);
            manager.SetNextAprover(regionalDirector);

            treasurer.ProcessRequest(model);
            return View(model);

        }
    }
}
