using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
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
        private readonly TelemetryClient _telemetryClient;

        public AlunoController(ApplicationDbContext context, TelemetryClient telemetryClient)
        {
            _dbContext = context;
            _telemetryClient = telemetryClient;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var alunos = _dbContext.Alunos.Include(a => a.Matriculas).ToList();

                return CreatedAtAction(nameof(Get), new ApiResponse<List<Aluno>>(true, "Cursos encontrados", alunos));
            }


            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua solicitação.", details = ex.Message });
            }
        }


        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Aluno aluno)
        {
            //var aluno = new Aluno();
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
                return StatusCode(500, new ApiResponse<string>(false, "Ocorreu um erro ao processar sua solicitação..", ex.Message));
            }
        }

        private string GerarNumeroMatricula()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

    }
}
