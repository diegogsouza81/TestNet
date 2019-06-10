using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using webAppApi.ADO;
using webAppApi.Models;

namespace webAppApi.Controllers
{
    [RoutePrefix("api/Pessoas")]
    public class PessoasController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Pessoas
        [HttpGet]
        [Route("")]
        public IQueryable<Pessoa> GetPessoas()
        {
            return db.Pessoas;
        }


        /// <summary>
        ///  Escreva o codigo em Linq para executar ordenação descendente por Sobrenome de uma
        ///  lista da classe acima(List<Pessoa>)
        /// </summary>
        /// <returns></returns>
        ///  [ActionName("GetMessageId")]
        ///  
        [Route("GetPessoasOrderByDescendingSobrenome")]        
        public List<Pessoa> GetPessoasOrderByDescendingSobrenome()
        {
            var result = db.Pessoas.Include(b => b.Empresa).OrderByDescending(x => x.Sobrenome).ToList<Pessoa>();
            return result;

        }

        /// <summary>
        /// Escreva um loop na mesma classe usando Parallel.ForEach (ou Parallel.For) que faça a
        //  iteração em todos os itens da lista.
        /// </summary>
        /// <param name="pessoas"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("ParallelForeach")]
        public List<Pessoa> ParallelForeach()
        {
            var result = db.Pessoas.Include(b => b.Empresa).ToList<Pessoa>();
            List<Pessoa> listaRetorno = new List<Pessoa>();
            Parallel.ForEach(result, (pessoa) =>
            {
                listaRetorno.Add(pessoa);
            });
            return listaRetorno;
        }
        // GET: api/Pessoas/5
        [ResponseType(typeof(Pessoa))]
        public async Task<IHttpActionResult> GetPessoa(int id)
        {
            Pessoa pessoa = await db.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }

        // PUT: api/Pessoas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPessoa(int id, Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            db.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pessoas
        [ResponseType(typeof(Pessoa))]
        public async Task<IHttpActionResult> PostPessoa(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pessoas.Add(pessoa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pessoa.Id }, pessoa);
        }

        // DELETE: api/Pessoas/5
        [ResponseType(typeof(Pessoa))]
        public async Task<IHttpActionResult> DeletePessoa(int id)
        {
            Pessoa pessoa = await db.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            db.Pessoas.Remove(pessoa);
            await db.SaveChangesAsync();

            return Ok(pessoa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoaExists(int id)
        {
            return db.Pessoas.Count(e => e.Id == id) > 0;
        }
    }
}