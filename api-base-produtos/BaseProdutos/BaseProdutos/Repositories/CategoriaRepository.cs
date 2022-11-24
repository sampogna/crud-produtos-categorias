using BaseProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseProdutos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        public readonly bsqlnpuzvdf6h32xq0aeContext _context;

        public CategoriaRepository(bsqlnpuzvdf6h32xq0aeContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task Delete(int id)
        {
            var categoriaDelete = await _context.Categoria.FindAsync(id);
            _context.Categoria.Remove(categoriaDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> Get()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Categoria> Get(int id)
        {
            return await _context.Categoria.FindAsync(id);
        }

        public async Task Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
