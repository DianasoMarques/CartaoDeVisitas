using CartaoDeVisitas.Data;
using CartaoDeVisitas.Entidades;
using CartaoDeVisitas.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CartaoDeVisitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoVisitasController : ControllerBase
    {
        private readonly Context _context;

        public CartaoVisitasController(Context context)
        {
            _context = context;
        }

        // GET: api/CartaoVisitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartaoVisita>>> GetCartaoVisita()
        {
            var resultado = await _context.CartaoVisita.ToListAsync();

            return resultado;
        }

        // GET: api/CartaoVisitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartaoVisita>> GetCartaoVisita(int id)
        {
            var cartaoVisita = await _context.CartaoVisita.FindAsync(id);

            if (cartaoVisita == null)
            {
                return NotFound();
            }

            return cartaoVisita;
        }

        // PUT: api/CartaoVisitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartaoVisita(int id, CartaoVisita cartaoVisita)
        {
           var recebe = await _context.CartaoVisita.FindAsync(id);
          
            if (id != cartaoVisita.Id)
            {
                return BadRequest();
            }
            if(recebe == null) { return BadRequest(); }

            _context.Entry(cartaoVisita).State = EntityState.Modified;

            try
            {
                cartaoVisita.DataCriacao = recebe.DataCriacao;
                cartaoVisita.DataAtualizacao = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoVisitaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartaoVisitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntradaCartaoVisitaDTO>> PostCartaoVisita(EntradaCartaoVisitaDTO entradaCartaoVisitaDTO)
        {
            var recebe = await _context.CartaoVisita.FirstAsync(x => x.Email.Equals(entradaCartaoVisitaDTO.Email));
            if (recebe == null) { return BadRequest(); }
            if (recebe.Email == entradaCartaoVisitaDTO.Email) { return NotFound ("Email já utilizado. Favor verificar.");}
            
            CartaoVisita cartaoVisita = new () 
            {
                Id = 0,
                NomeCompleto = entradaCartaoVisitaDTO.NomeCompleto,
                NomeEmpresa = entradaCartaoVisitaDTO.NomeEmpresa,
                ProfissaoCargo = entradaCartaoVisitaDTO.ProfissaoCargo,
                Telefone1 = entradaCartaoVisitaDTO.Telefone1,
                Telefone2 = entradaCartaoVisitaDTO.Telefone2,
                Email = entradaCartaoVisitaDTO.Email,
                Facebook = entradaCartaoVisitaDTO.Facebook,
                Instagram = entradaCartaoVisitaDTO.Instagram,
                Twitter = entradaCartaoVisitaDTO.Twitter,
                YouTube = entradaCartaoVisitaDTO.YouTube,
                Linkedin = entradaCartaoVisitaDTO.Linkedin,
                DataCriacao = DateTime.Now

            };

            _context.CartaoVisita.Add(cartaoVisita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartaoVisita", new { id = cartaoVisita.Id }, cartaoVisita);
        }

        // DELETE: api/CartaoVisitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartaoVisita(int id)
        {
            var cartaoVisita = await _context.CartaoVisita.FindAsync(id);
            if (cartaoVisita == null)
            {
                return NotFound();
            }

            _context.CartaoVisita.Remove(cartaoVisita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartaoVisitaExists(int id)
        {
            return _context.CartaoVisita.Any(e => e.Id == id);
        }
    }
}
