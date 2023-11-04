using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyUniversityAPI.Data;
using MyUniversityAPI.Models;


namespace MyUniversityAPI.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET api/student
        public IEnumerable<Aluno> Get()
        {
            
            return new List<Aluno>();
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataNascimento,NumeroMatricula")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                dbContext.Alunos.Add(aluno);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }


        // PUT api/student/5
        public void Put(int id,  Aluno aluno)
        {
            // Aqui você vai atualizar um estudante pelo ID
        }

        // DELETE api/student/5
        public void Delete(int id)
        {
            // Aqui você vai deletar um estudante pelo ID
        }
    }
}