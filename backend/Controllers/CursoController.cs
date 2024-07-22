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


                return Ok(new ApiResponse<List<CursoDto>>(true, "Cursos encontrados", cursoDtos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Erro ao buscar cursos", ex.Message));
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(CursoDto cursoDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<Disciplina> disciplinas = new List<Disciplina>();
                    if (cursoDto.Disciplinas != null)
                    {

                        foreach (var item in cursoDto.Disciplinas)
                        {
                            Disciplina disciplina = new Disciplina
                            {
                                Nome = item.Nome,
                                CursoId = item.Id,
                                ProfessorId = item.ProfessorId,
                            };

                            Professor professor = new Professor();
                            professor = await _dbContext.Professors.FirstOrDefaultAsync(x => x.Id == disciplina.ProfessorId);

                            if (professor != null)
                            {
                                disciplina.ProfessorId = professor.Id;
                            }
                            else
                            {
                                disciplina.Professor = null;
                            }

                            disciplinas.Add(disciplina);
                        };

                    }

                    Curso curso = new Curso
                    {
                        Nome = cursoDto.Nome,
                        Disciplinas = disciplinas
                    };


                    _dbContext.Cursos.Add(curso);
                    await _dbContext.SaveChangesAsync();

                    return Ok(new ApiResponse<Curso>(true, "Curso cadastrado com sucesso", curso));

                }
                else
                {
                    var message = "";
                    return StatusCode(500, new ApiResponse<string>(false, "Dados de entrada inválidos.", message));

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ocorreu um erro ao processar sua solicitação..", ex.Message });
            }
        }

    }

}
