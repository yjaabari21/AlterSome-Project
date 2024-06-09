using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AlterSome.Models;

namespace AlterSome.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		
		public ActionResult List()
		{
			using (var cxt = new AlterSomeEntities())
			{
				var data = cxt.Alters.AsQueryable().OrderByDescending(x => x.Id).ToList();
				List<Alter> list = new List<Alter>();
				foreach (var item in data)
                {
					list.Add(
						new Alter
						{
							Id = item.Id,
							ImageApp = item.ImageApp,
							Name = item.Name,
							LinkUrl = item.LinkUrl,
							//LinkUrl2 = item.LinkUrl2,
							//LinkUrl3 = item.LinkUrl3,
							Description = item.Description,
						}
						);
                };
				return View(list);
            }
		}
	}
}