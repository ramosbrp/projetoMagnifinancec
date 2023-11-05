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
    public class AlunoController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();



        [HttpGet]
        public ActionResult Index()

        {
            // Inclui as Matriculas relacionadas com cada Aluno
            //var alunosComMatriculas = dbContext.Alunos.Include(a => a.Matriculas).ToList();

            var alunosComMatriculas = "ok";

            // Retorna a lista como JSON
            return Json(alunosComMatriculas, JsonRequestBehavior.AllowGet);
        }

        // GET api/student/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Aluno aluno = dbContext.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        [HttpPost]
        public Aluno Create([Bind(Include = "Id,Nome,DataNascimento,NumeroMatricula")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                dbContext.Alunos.Add(aluno);
                dbContext.SaveChanges();
            }

            return aluno;
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