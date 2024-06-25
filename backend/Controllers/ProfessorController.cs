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
    public class ProfessorController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public ProfessorController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            List<Professor> professores = new List<Professor>();
            professores = await _dbContext.Professors
            .ToListAsync();

            List<ProfessorDto> professoresDto = new List<ProfessorDto>();

            professoresDto = professores.Select(p => new ProfessorDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Disciplinas = p.Disciplinas.Select(d => new DisciplinaDto
                {
                    Id = d.Id,
                    Nome = d.Nome,
                }).ToList()
            }).ToList();

            return CreatedAtAction(nameof(Get), new ApiResponse<List<Professor>>(true, "Cursos encontrados", professores));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _dbContext.Professors.Add(professor);
                    await _dbContext.SaveChangesAsync();

                    return CreatedAtAction(nameof(Create), new { id = professor.Id }, professor);

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
