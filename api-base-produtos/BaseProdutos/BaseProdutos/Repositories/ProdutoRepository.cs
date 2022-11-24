using BaseProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseProdutos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        public readonly bsqlnpuzvdf6h32xq0aeContext _context;

        public ProdutoRepository(bsqlnpuzvdf6h32xq0aeContext context)
        {
            _context = context;
        }
        public async Task<Produto> Create(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Delete(int id)
        {
            var produtoDelete = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produtoDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            
            return await _context.Produto.AsQueryable().Include(p => p.Categoria).ToListAsync();
        }

        public async Task<Produto> Get(int id)
        {
            return await _context.Produto.AsQueryable().Include(p => p.Categoria).FirstOrDefaultAsync(p => p.ID_Produto == id);
        }

        public async Task Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
