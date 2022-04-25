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
    public class RezumesController : Controller
    {
        private rabotaEntities db = new rabotaEntities();

        // GET: Rezumes
        public ActionResult Index()
        {
            return View(db.Rezume.ToList());
        }

        // GET: Rezumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezume rezume = db.Rezume.Find(id);
            if (rezume == null)
            {
                return HttpNotFound();
            }
            return View(rezume);
        }

        // GET: Rezumes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezumes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Фамилия,Имя,Отчество,Возраст,Опыт_работы,Образование,Желаемый_доход,О_себе")] Rezume rezume)
        {
            if (ModelState.IsValid)
            {
                db.Rezume.Add(rezume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezume);
        }

        // GET: Rezumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezume rezume = db.Rezume.Find(id);
            if (rezume == null)
            {
                return HttpNotFound();
            }
            return View(rezume);
        }

        // POST: Rezumes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Фамилия,Имя,Отчество,Возраст,Опыт_работы,Образование,Желаемый_доход,О_себе")] Rezume rezume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezume);
        }

        // GET: Rezumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezume rezume = db.Rezume.Find(id);
            if (rezume == null)
            {
                return HttpNotFound();
            }
            return View(rezume);
        }

        // POST: Rezumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezume rezume = db.Rezume.Find(id);
            db.Rezume.Remove(rezume);
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
