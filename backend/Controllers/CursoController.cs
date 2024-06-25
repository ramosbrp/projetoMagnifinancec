using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyUniversityAPP.Data;
using MyUniversityAPP.Models;
using MyUniversityAPP.Models.DTO;
using System.Drawing.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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
                // Tente buscar o primeiro registro de uma tabela de forma síncrona
                var item = await _dbContext.Usuario.FirstOrDefaultAsync();  // Substitua "MinhaTabela" pelo nome real da sua tabela
                if (item != null)
                {
                    return Ok("Conexão com o banco de dados foi um sucesso!");
                }
                else
                {
                    return Ok("Conexão estabelecida, mas a tabela está vazia.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao conectar ao banco de dados: {ex.Message}");
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
