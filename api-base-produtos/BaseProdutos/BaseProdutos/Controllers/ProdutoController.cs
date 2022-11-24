using BaseProdutos.Models;
using BaseProdutos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BaseProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await _produtoRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            return await _produtoRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto([FromBody] Produto produto)
        {
            var newProduto = await _produtoRepository.Create(produto);
            return CreatedAtAction(nameof(GetProdutos), new { id = newProduto.ID_Produto }, newProduto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            var produtoToDelete = await _produtoRepository.Get(id);

            if (produtoToDelete != null)
            {
                await _produtoRepository.Delete(produtoToDelete.ID_Produto);
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult> PutProduto(int id, [FromBody] Produto produto)
        {
            if (id == produto.ID_Produto)
            {
                await _produtoRepository.Update(produto);
            }
            else
            {
                return BadRequest();
            }

            return NotFound();
        }
    }

}
