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
using MyUniversityAPI.Models.DTO;
using MyUniversityAPI.Models.Dto;

namespace MyUniversityAPI.Controllers
{
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                List<Curso> cursos = new List<Curso>();
                cursos = await dbContext.Cursos.ToListAsync();

                List<CursoDto> cursoDtos = new List<CursoDto>();

                cursoDtos = cursos.Select(c => new CursoDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Disciplinas = c.Disciplinas.Select(p => new DisciplinaDto
                    {
                        Id=p.Id,
                        Nome=p.Nome,
                    }
                    ).ToList()

                }).ToList();

                return Json(cursoDtos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = "Ocorreu um erro ao processar sua solicitação...." });
            }
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