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
    public class AlunoController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public AlunoController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]

        public ActionResult Get()
        {
            //Inclui as Matriculas relacionadas com cada Aluno
            var alunos = _dbContext.Alunos.Include(a => a.Matriculas).ToList();

            // Retorna a lista como JSON
            return CreatedAtAction(nameof(Get), new ApiResponse<List<Aluno>>(true, "Cursos encontrados", alunos));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aluno.NumeroMatricula = GerarNumeroMatricula();

                    _dbContext.Alunos.Add(aluno);
                    await _dbContext.SaveChangesAsync();

                    return CreatedAtAction(nameof(Create), new { id = aluno.Id }, aluno);

                }
                else
                {
                    var message = "";
                    return StatusCode(500, new ApiResponse<string>(false, "Dados de entrada inválidos.", message));

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Dados de entrada inválidos.", ex.Message));
            }
        }

        private string GerarNumeroMatricula()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

    }
}
