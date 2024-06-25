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
    public class CursoController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public CursoController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            try
            {

                List<Curso> cursos = new List<Curso>();
                cursos = await _dbContext.Cursos.ToListAsync();

                List<CursoDto> cursoDtos = new List<CursoDto>();

                cursoDtos = cursos.Select(c => new CursoDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Disciplinas = c.Disciplinas.Select(p => new
                    DisciplinaDto
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                    }

                    ).ToList()
                }).ToList();


                return CreatedAtAction(nameof(Create), new ApiResponse<List<CursoDto>>(true, "Cursos encontrados", cursoDtos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Erro ao buscar cursos", ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _dbContext.Cursos.Add(curso);
                    await _dbContext.SaveChangesAsync();

                    return CreatedAtAction(nameof(Create), new { id = curso.Id }, curso);

                }
                else
                {
                    var message = "";
                    return StatusCode(500, new ApiResponse<string>(false, "Dados de entrada inválidos.", message));

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ocorreu um erro ao processar sua solicitação.." });
            }
        }

    }
}
