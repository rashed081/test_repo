using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YourAcademy.Models;
using YourAcademy.Web.Models;

namespace YourAcademy.Controllers
{
    public class HomeController : Controller
    {
        ILifetimeScope _scope;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

       
        public IActionResult Index()
        {
            var model = _scope.Resolve<CourseViewModel>();
            var courseId = new Guid("DA90CD92-FC49-4E49-86FB-1648AF56C01D");
            var data = model.GetCourse(courseId);
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
