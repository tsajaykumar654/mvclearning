using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class CSPPunchController : Controller
    {
        private MVCAppDatabaseEntities db = new MVCAppDatabaseEntities();
        // GET: CSPPunch
        public ActionResult Index(string sortOrder, int? page)
        {
            List<CSPPunchList> CSPPunchList = new List<CSPPunchList>();
            ViewBag.DateSort = String.IsNullOrEmpty(sortOrder) ? "DateSort" : "";

            var CSPPunches = from s in db.CSPPunches
                             join y in db.CSPDetails
     on s.UserId equals y.id
                             select new { s.CreateDate, s.PunchIn, s.PunchOut, s.UserId, s.id, y.Name };

            switch (sortOrder)
            {
                case "DateSort":
                    CSPPunches = CSPPunches.OrderByDescending(s => s.CreateDate);
                    break;

                default:
                    CSPPunches = CSPPunches.OrderBy(s => s.CreateDate);
                    break;
            }

            foreach (var item in CSPPunches)
            {
                CSPPunchList CSPPunch = new CSPPunchList();
                CSPPunch.PunchIn = item.PunchIn;
                CSPPunch.PunchOut = item.PunchOut;
                CSPPunch.CreateDate = item.CreateDate;
                CSPPunch.Name = item.Name;
                CSPPunch.UserId = int.Parse(item.UserId.ToString());
                CSPPunch.id = int.Parse(item.id.ToString());
                CSPPunchList.Add(CSPPunch);
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(CSPPunchList.ToPagedList(pageNumber, pageSize));

            //return View(CSPPunches.ToList());
        }

        public ActionResult Details(int? id)
        {
            CSPPunchList CSPPunchList = new CSPPunchList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CSPPunch = from s in db.CSPPunches
                           join y in db.CSPDetails
   on s.UserId equals y.id
                           where s.id == id
                           select new { s.CreateDate, s.PunchIn, s.PunchOut, s.UserId, s.id, y.Name };

            //CSPPunch CSPPunch = db.CSPPunches.Find(id);
            if (CSPPunch == null)
            {
                return HttpNotFound();
            }

            foreach (var item in CSPPunch)
            {
                CSPPunchList.PunchIn = item.PunchIn;
                CSPPunchList.PunchOut = item.PunchOut;
                CSPPunchList.CreateDate = item.CreateDate;
                CSPPunchList.Name = item.Name;
                CSPPunchList.UserId = int.Parse(item.UserId.ToString());
                CSPPunchList.id = int.Parse(item.id.ToString());
            }

            return View(CSPPunchList);
        }
    }
}