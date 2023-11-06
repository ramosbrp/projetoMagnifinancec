using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyUniversityAPI.Data;
using MyUniversityAPI.Models;
using System.Data.Entity;
using MyUniversityAPI.App_Start;

namespace MyUniversityAPI.Controllers
{
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            //Inclui as Disciplinas relacionadas com cada Curso
            var cursos = dbContext.Cursos.Include(a => a.Disciplinas).ToList();

            // Retorna a lista como JSON
            return Json(cursos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = dbContext.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }

            return View(curso);
        }

        [HttpPost]
        public Curso Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                dbContext.Cursos.Add(curso);
                dbContext.SaveChanges();
            }


            return curso;
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}