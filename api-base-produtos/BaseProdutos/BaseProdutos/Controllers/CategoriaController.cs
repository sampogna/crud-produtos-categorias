using BaseProdutos.Models;
using BaseProdutos.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BaseProdutos.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _categoriaRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id) 
        { 
            return await _categoriaRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria([FromBody] Categoria categoria)
        {
            var newCategoria = await _categoriaRepository.Create(categoria);
            return CreatedAtAction(nameof(GetCategorias), new { id = newCategoria.ID_Categoria}, newCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoria(int id)
        {
            var categoriaToDelete = await _categoriaRepository.Get(id);

            if (categoriaToDelete != null) 
            {
                await _categoriaRepository.Delete(categoriaToDelete.ID_Categoria);
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategoria(int id, [FromBody] Categoria categoria)
        {
            if (id == categoria.ID_Categoria)
            {
                await _categoriaRepository.Update(categoria);
            }
            else
            {
                return BadRequest();
            }

            return NotFound();
        }
    }
}
