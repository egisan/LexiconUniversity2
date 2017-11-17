using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiconUniversity.DataAccess;
using LexiconUniversity.Models;
using System.Web.UI;

namespace LexiconUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private LexiconUniversityContext db = new LexiconUniversityContext();

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView(student);
            }
            else
            {
                return View(student);
            }
        }

        public JsonResult DetailsJson(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Student student = db.Students.Find(id);

            var studentVM = new Student
            {
                Id  = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
            //if (student == null)
            //{
            //    return HttpNotFound();
            //}
            return Json(studentVM, JsonRequestBehavior.AllowGet);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid && student.LastName != "Fail")
            {
                db.Students.Add(student);
                db.SaveChanges();
                // return View();
                var students = db.Students.ToList();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("ListPartial", students);
                }
                else
                {
                    return View();
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult ListPartial()
        {
            return PartialView(db.Students.ToList());
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
