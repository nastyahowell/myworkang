using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mywork.Models;

namespace mywork.Controllers
{
    public class VakansiisController : Controller
    {
        private rabotaEntities db = new rabotaEntities();

        // GET: Vakansiis
        public ActionResult Index()
        {
            return View(db.Vakansii.ToList());
        }

        // GET: Vakansiis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vakansii vakansii = db.Vakansii.Find(id);
            if (vakansii == null)
            {
                return HttpNotFound();
            }
            return View(vakansii);
        }

        // GET: Vakansiis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vakansiis/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Организация,Должность,Требования,Функционал,Формат_работы,Доход,График,Условия")] Vakansii vakansii)
        {
            if (ModelState.IsValid)
            {
                db.Vakansii.Add(vakansii);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vakansii);
        }

        // GET: Vakansiis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vakansii vakansii = db.Vakansii.Find(id);
            if (vakansii == null)
            {
                return HttpNotFound();
            }
            return View(vakansii);
        }

        // POST: Vakansiis/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Организация,Должность,Требования,Функционал,Формат_работы,Доход,График,Условия")] Vakansii vakansii)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vakansii).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vakansii);
        }

        // GET: Vakansiis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vakansii vakansii = db.Vakansii.Find(id);
            if (vakansii == null)
            {
                return HttpNotFound();
            }
            return View(vakansii);
        }

        // POST: Vakansiis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vakansii vakansii = db.Vakansii.Find(id);
            db.Vakansii.Remove(vakansii);
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
    }
}
