using AvaliacaoCursoFormacao.Data;
using AvaliacaoCursoFormacao.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoCursoFormacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private CursoContext db = new CursoContext();

        [HttpGet("findAll")]
        public async Task<IActionResult> findAll()
        {

            try
            {
                var curso = db.Cursos.ToList();
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CursoRequest curso)
        {
            try
            {
                Curso cursouinst = new Curso()
                {
                    descricao = curso.descricao,
                    dataInicio = Convert.ToDateTime(curso.dataInicio),
                    dataFim = Convert.ToDateTime(curso.dataFim),
                    qtdAluno = curso.qtdAluno,
                    categoriaid = curso.categoria.id
                };

                if (db.Cursos.Count(x => x.dataInicio <= cursouinst.dataFim && x.dataFim >= cursouinst.dataInicio) > 0)
                {
                    return BadRequest("Existe(m) curso(s) planejados(s) dentro do período informado");
                }
                else if (cursouinst.dataInicio < DateTime.Now)
                {
                    return BadRequest("Data inválida");
                }
                else if (cursouinst.dataFim < cursouinst.dataInicio)
                {
                    return BadRequest("Data inválida");
                }

                db.Cursos.Add(cursouinst);

                db.SaveChanges();
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CursoRequest curso)
        {
            try
            {
                Curso cursoupdt = new Curso()
                {
                    id = id,
                    descricao = curso.descricao,
                    dataInicio = Convert.ToDateTime(curso.dataInicio),
                    dataFim = Convert.ToDateTime(curso.dataFim),
                    qtdAluno = curso.qtdAluno,
                    categoriaid = curso.categoria.id
                };
                
                if (db.Cursos.Count(x => x.dataInicio <= cursoupdt.dataFim&& x.dataFim >= cursoupdt.dataInicio) > 0)
                {
                    return BadRequest("Existe(m) curso(s) planejados(s) dentro do período informado");
                }
                else if (cursoupdt.dataFim < cursoupdt.dataInicio)
                {
                    return BadRequest("Data inválida");
                }

                db.Entry(cursoupdt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(cursoupdt);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                db.Cursos.Remove(db.Cursos.Find(id));
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


    }

}
