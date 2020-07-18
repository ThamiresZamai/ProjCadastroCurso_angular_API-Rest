using AvaliacaoCursoFormacao.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoCursoFormacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CursoContext db = new CursoContext();

        [HttpGet ("findAll")]
        public async Task<IActionResult> findAll() {

            try
            {
                var categorias = db.Categorias.ToList();
                return Ok(categorias);
            }
            catch {
                return BadRequest();
            }

        }
    }
}