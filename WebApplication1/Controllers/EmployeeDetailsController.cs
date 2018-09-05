using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Net;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class EmployeeDetailsController : Controller
    {

        // GET: EmployeeDetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllData()
        {
            using (MVCAppDatabaseEntities _context = new MVCAppDatabaseEntities())
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                var customerData = (from tempcustomer in _context.CSPDetails
                                    select tempcustomer);

                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Name == searchValue);
                }

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                //var data = customerData.Skip(skip).Take(pageSize).ToList();
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
        }

        // GET: CSPDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            using (MVCAppDatabaseEntities _context = new MVCAppDatabaseEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CSPDetail cSPDetail = _context.CSPDetails.Find(id);
                if (cSPDetail == null)
                {
                    return HttpNotFound();
                }
                return View(cSPDetail);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserId,Name,CreateDate,Finger1,Finger2,Finger3,Finger4,IsDeleted,UserTypeId")] CSPDetail cSPDetail)
        {
            using (MVCAppDatabaseEntities _context = new MVCAppDatabaseEntities())
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(cSPDetail).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cSPDetail);
            }
        }

        // POST: CSPDetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (MVCAppDatabaseEntities _context = new MVCAppDatabaseEntities())
            {
                CSPDetail cSPDetail = _context.CSPDetails.Find(id);
                _context.CSPDetails.Remove(cSPDetail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}