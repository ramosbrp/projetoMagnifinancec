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
        public async Task<ActionResult> Create(Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.Professors.Add(professor);
                    await dbContext.SaveChangesAsync();

                    // Retorna o número de matrícula gerado
                    return Json(professor);
                }
                else
                {
                    // Se o modelo não for válido, retorne os erros de validação
                    return Json(new { error = "Dados de entrada inválidos." });
                }
            }
            catch (Exception)
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