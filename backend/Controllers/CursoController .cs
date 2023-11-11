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
using System.Threading.Tasks;

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
        public async Task<ActionResult> Create(Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Professor professor = dbContext.Professors.Find(curso.Disciplinas.First().ProfessorId);

                    curso.Disciplinas.First().Professor = professor;

                    dbContext.Cursos.Add(curso);
                    await dbContext.SaveChangesAsync();

                    return Json(curso);
                }else
                {
                    return Json(new { error = "Dados de entrada inválidos." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = "Ocorreu um erro ao processar sua solicitação.." });
            }
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