using System.Web.Mvc;
using EasyDI.Sample.Contracts.Interfaces;
using EasyDI.Sample.WebUI.Services;

namespace EasyDI.Sample.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IExternalService _myService;
        private readonly ILocalService _anotherService;

        public HomeController(IExternalService myService, ILocalService anotherService)
        {
            _myService = myService;
            _anotherService = anotherService;
        }

        public ActionResult Index()
        {
            _myService.TerrificMethodOne();
            ViewBag.myServiceResult = _myService.SayHello();
            ViewBag.anotherServiceResult = _anotherService.GuessWhat();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}