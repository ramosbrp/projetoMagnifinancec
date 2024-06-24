using Microsoft.AspNetCore.Mvc;
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
                List<CursoDto> cursos = new List<CursoDto>();

                CursoDto curso = new CursoDto
                {
                    Id = 1,
                    Nome = "Física"
                };

                cursos.Add(curso);

                // Note que o tipo genérico agora é List<CursoDto> ao invés de CursoDto
                return Ok(new ApiResponse<List<CursoDto>>(true, "Cursos encontrados", cursos));
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>(false, "Erro ao buscar cursos", ex.Message));
            }
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
