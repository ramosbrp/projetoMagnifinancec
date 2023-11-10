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
using Microsoft.Ajax.Utilities;

namespace MyUniversityAPI.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();



        [HttpGet]
        public ActionResult Index()
        {
            //Inclui as Matriculas relacionadas com cada Aluno
            var alunosComMatriculas = dbContext.Alunos.Include(a => a.Matriculas).ToList();

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
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aluno.NumeroMatricula = GerarNumeroMatricula();

                    dbContext.Alunos.Add(aluno);
                    await dbContext.SaveChangesAsync();

                    // Retorna o número de matrícula gerado
                    return Json (aluno);
                }
                else
                {
                    // Se o modelo não for válido, retorne os erros de validação
                    return Json(new { error = "Dados de entrada inválidos." });
                }

            }
            catch (Exception ex)
            {
                return Json(new { error = "Ocorreu um erro ao processar sua solicitação." });
            }

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

        private string GerarNumeroMatricula()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
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