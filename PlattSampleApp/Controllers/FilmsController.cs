using PlattSampleApp.AppCode.Data;
using System.Web.Mvc;

namespace PlattSampleApp.Controllers
{
	public class FilmsController : Controller
	{
		private readonly IDataContext db;

		public FilmsController(IDataContext context)
		{
			db = context;
		}

		public ActionResult Details(int id)
		{
			var model = db.GetFilmByEpisodeId(id);

			return View(model);
		}

		public ActionResult Index()
		{
			var model = db.GetFilms();

			return View(model);
		}
	}
}