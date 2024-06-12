using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tdtlession07.Models;

namespace Tdtlession07.Controllers
{
    public class TdtKhoasController : Controller
    {
        private TDTaspEntities1 db = new TDTaspEntities1();

        // GET: TdtKhoas
        public ActionResult TdtIndex()
        {
            return View(db.TdtKhoa.ToList());
        }

        // GET: TdtKhoas/Details/5
        public ActionResult TdtDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TdtKhoa tdtKhoa = db.TdtKhoa.Find(id);
            if (tdtKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tdtKhoa);
        }

        // GET: TdtKhoas/Create
        public ActionResult TdtCreate()
        {
            return View();
        }

        // POST: TdtKhoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TdtCreate([Bind(Include = "TdtMaKH,TdtTenKH,TdtTrangThai")] TdtKhoa tdtKhoa)
        {
            if (ModelState.IsValid)
            {
                db.TdtKhoa.Add(tdtKhoa);
                db.SaveChanges();
                return RedirectToAction("TdtIndex");
            }

            return View(tdtKhoa);
        }

        // GET: TdtKhoas/Edit/5
        public ActionResult TdtEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TdtKhoa tdtKhoa = db.TdtKhoa.Find(id);
            if (tdtKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tdtKhoa);
        }

        // POST: TdtKhoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TdtEdit([Bind(Include = "TdtMaKH,TdtTenKH,TdtTrangThai")] TdtKhoa tdtKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tdtKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TdtIndex");
            }
            return View(tdtKhoa);
        }

        // GET: TdtKhoas/Delete/5
        public ActionResult TdtDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TdtKhoa tdtKhoa = db.TdtKhoa.Find(id);
            if (tdtKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tdtKhoa);
        }

        // POST: TdtKhoas/Delete/5
        [HttpPost, ActionName("TdtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TdtKhoa tdtKhoa = db.TdtKhoa.Find(id);
            db.TdtKhoa.Remove(tdtKhoa);
            db.SaveChanges();
            return RedirectToAction("TdtIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
