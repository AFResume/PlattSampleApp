using PlattSampleApp.AppCode.Data;
using PlattSampleApp.AppCode.Interfaces;
using PlattSampleApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace PlattSampleApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IDataContext db;

		public HomeController(IDataContext context)
		{
			db = context;
		}

		public ActionResult GetAllPlanets()
		{
			IPlanets planets = db.GetAllPlanets();

			if (planets == null)
				return HttpNotFound();

			var model = new AllPlanetsViewModel(planets);

			return View(model);
		}

		/// AF: Action method and input parameter's original names remained unchanged, but if I was given a choice,
		/// I would have the method renamed to GetPlanet to make it more generic. I would also change the parameter's
		/// name to Id, so that it could also be passed in URL (using default route pattern defined in RouteConfig).
		public ActionResult GetPlanetTwentyTwo(int planetid)
		{
			IPlanet planet = db.GetPlanetById(planetid);
			var model = new SinglePlanetViewModel(planetid, planet);

			return View(model);
		}

		/// AF: Action method's original name remained unchanged, but if I was given a choice
		/// I would rename it to GetResidentsOfPlanet to make it more generic.
		public ActionResult GetResidentsOfPlanetNaboo(string planetname)
		{
			var residents = db.GetPlanetResidents(planetname);

			if (residents == null)
				return HttpNotFound();

			var model = new PlanetResidentsViewModel(planetname, residents.OrderBy(n => n.Name));

			return View(model);
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult VehicleSummary()
		{
			var vehicles = db.GetAllVehicles();
			var model = new VehicleSummaryViewModel(vehicles);

			return View(model);
		}
	}
}