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
    public class ProfessorController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            //Inclui as Matriculas relacionadas com cada Professor
            var professores = dbContext.Professors.Include(a => a.Disciplinas).ToList();

            // Retorna a lista como JSON
            return Json(professores, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Professor professores = dbContext.Professors.Find(id);
            if (professores == null)
            {
                return HttpNotFound();
            }

            return View(professores);
        }

        [HttpPost]
        public Professor Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                dbContext.Professors.Add(professor);
                dbContext.SaveChanges();
            }


            return professor;
        }


        // PUT api/student/5
        public void Put(int id, Aluno aluno)
        {
            // Aqui você vai atualizar um estudante pelo ID
        }

        // DELETE api/student/5
        public void Delete(int id)
        {
            // Aqui você vai deletar um estudante pelo ID
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