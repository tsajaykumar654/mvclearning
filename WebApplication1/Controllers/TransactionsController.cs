using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using System.Linq.Dynamic;

namespace WebApplication1.Controllers
{
    public class TransactionsController : Controller
    {
        private MVCAppDatabaseEntities db = new MVCAppDatabaseEntities();

        // GET: Transactions
        public ActionResult Index(string sortOrder, int? page, string searchString)
        {
            int pageSize = 0, pageNumber = 0;
            IQueryable<Transaction> Transactions;
            ViewBag.paymentMode = String.IsNullOrEmpty(sortOrder) ? "paymentMode" : "";
            ViewBag.paymentDate = String.IsNullOrEmpty(sortOrder) ? "paymentDate" : "";
            ViewBag.ReceiptNo = String.IsNullOrEmpty(sortOrder) ? "ReceiptNo" : "";
            ViewBag.MachineID = String.IsNullOrEmpty(sortOrder) ? "MachineID" : "";
            ViewBag.KioskID = String.IsNullOrEmpty(sortOrder) ? "KioskID" : "";


            pageSize = 20;

            if (!String.IsNullOrEmpty(searchString))
            {
                page = 1;
                pageNumber = (page ?? 1);
                Transactions = from s in db.Transactions where s.ConsumerNo.Contains(searchString) orderby s.PaymentMode select s;
                return View(Transactions.ToPagedList(pageNumber, pageSize));
            }

            pageNumber = (page ?? 1);
            switch (sortOrder)
            {
                case "paymentMode":
                    Transactions = from s in db.Transactions orderby s.PaymentMode select s;
                    break;
                case "paymentDate":
                    Transactions = from s in db.Transactions orderby s.PaymentDate select s;
                    break;
                case "ReceiptNo":
                    Transactions = from s in db.Transactions orderby s.ReceiptNo select s;
                    break;
                case "MachineID":
                    Transactions = from s in db.Transactions orderby s.MachineID select s;
                    break;
                case "KioskID":
                    Transactions = from s in db.Transactions orderby s.KioskID select s;
                    break;
                default:
                    Transactions = from s in db.Transactions orderby s.PaymentDate select s;
                    break;
            }


            return View(Transactions.ToPagedList(pageNumber, pageSize));
        }

        // GET: Transactions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ConsumerNo,Reference1,Reference2,Reference3,CustomerName,SubDivision,ServiceProvider,PaymentMode,PaymentDate,BillAmount,BillDate,BillDueDate,CollectionAmount,BatchAmount,ChequeNo,ChequeDate,MICR,MICRDATA,CardTransactionNo,BatchNo,ReceiptNo,BankCode,Denom1,Denom2,Denom3,Denom4,Denom5,Denom6,Denom7,Denom8,Denom9,Denom10,Denom11,Denom12,AdditionalInfo1,AdditionalInfo2,AdditionalInfo3,UpdatedToServerYN,DeclinedTransactionYN,DayEndClosedYN,ReceiptPrintCount,ErrorMessage,MachineID,KioskID,BillMonth,EncAc,EncCa,EncPd,InvoiceNo")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ConsumerNo,Reference1,Reference2,Reference3,CustomerName,SubDivision,ServiceProvider,PaymentMode,PaymentDate,BillAmount,BillDate,BillDueDate,CollectionAmount,BatchAmount,ChequeNo,ChequeDate,MICR,MICRDATA,CardTransactionNo,BatchNo,ReceiptNo,BankCode,Denom1,Denom2,Denom3,Denom4,Denom5,Denom6,Denom7,Denom8,Denom9,Denom10,Denom11,Denom12,AdditionalInfo1,AdditionalInfo2,AdditionalInfo3,UpdatedToServerYN,DeclinedTransactionYN,DayEndClosedYN,ReceiptPrintCount,ErrorMessage,MachineID,KioskID,BillMonth,EncAc,EncCa,EncPd,InvoiceNo")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
                var customerData = (from tempcustomer in _context.Transactions
                                    select tempcustomer);

                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.ConsumerNo == searchValue);
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

    }
}
