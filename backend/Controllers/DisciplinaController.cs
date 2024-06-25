using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyUniversityAPP.Data;
using MyUniversityAPP.Models;
using MyUniversityAPP.Models.DTO;
using System.Drawing.Text;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyUniversityAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public DisciplinaController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]

        public ActionResult Get()
        {
            //Inclui as Matriculas relacionadas com cada Aluno
            var disciplinas = _dbContext.Disciplinas.Include(a => a.Matriculas).ToList();

            // Retorna a lista como JSON
            return CreatedAtAction(nameof(Get), new ApiResponse<List<Disciplina>>(true, "Cursos encontrados", disciplinas));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Disciplina disciplina)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _dbContext.Disciplinas.Add(disciplina);
                    await _dbContext.SaveChangesAsync();

                    return CreatedAtAction(nameof(Create), new { id = disciplina.Id }, disciplina);

                }
                else
                {
                    var message = "";
                    return StatusCode(500, new ApiResponse<string>(false, "Dados de entrada inválidos.", message));

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Ocorreu um erro ao processar sua solicitação..", ex.Message));
            }
        }

        private string GerarNumeroMatricula()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

    }
}
