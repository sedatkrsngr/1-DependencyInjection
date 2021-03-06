using _1_DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _1_DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingletonDateService _singletonDateService;
        private readonly IScopedDateService _scopedDateService;
        private readonly ITransientDateService _transientDateService;

        public HomeController(ISingletonDateService singletonDateService, IScopedDateService scopedDateService, ITransientDateService transientDateService)
        {
            _singletonDateService = singletonDateService;  
            _scopedDateService = scopedDateService;
            _transientDateService = transientDateService;
        }

        public IActionResult Index([FromServices]ISingletonDateService singletonDateService2)//Singleton olduğu için sadece bir kez çalıştığı için üstteki ile aynı olacak. Sayfa yenilense dahi aynı olacak
        {
            ViewBag.time1 = _singletonDateService.GetDateTime.TimeOfDay.ToString();
            ViewBag.time2 = singletonDateService2.GetDateTime.TimeOfDay.ToString();

            return View();
        }

        public IActionResult Index([FromServices] IScopedDateService scopedDateService2)//Her istek yapıldığında aynı anda birden falza çağırılsa dahi ilk çağırıldığındaki değeri alır hepsi. Fakat Singletondan farkı sayfa yenilendiğinde değer de değişir. ama en nihayetinde ikisi yine aynı olur.
        {
            ViewBag.time1 = _scopedDateService.GetDateTime.TimeOfDay.ToString();
            ViewBag.time2 = scopedDateService2.GetDateTime.TimeOfDay.ToString();
            return View();
        }
        public IActionResult Index([FromServices] ITransientDateService transientDateService2)//Her istek yapıldığında ve yeniden çağrıldığında değişir. Bu yüzden ikisi aynı olmayacaktır.
        {
            ViewBag.time1 = _transientDateService.GetDateTime.TimeOfDay.ToString();
            ViewBag.time2 = transientDateService2.GetDateTime.TimeOfDay.ToString();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
