using GlobalWeatherServiceClient.DL;
using System.Web.Mvc;

namespace GlobalWeatherServiceClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCitiesByCountry(string countryName)
        {
            return Json(GlobalWeather.GetCitiesByCountryJSON(countryName), JsonRequestBehavior.AllowGet);
        }
    }
}