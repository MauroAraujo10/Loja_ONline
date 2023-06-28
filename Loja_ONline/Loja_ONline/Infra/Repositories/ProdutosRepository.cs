using Loja_ONline.Entities;
using Loja_ONline.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja_ONline.Infra.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly DataContext _dataContext;

        public ProdutosRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Produtos>> GetAll()
        {
            return await _dataContext.Products.Include(x => x.Usuarios).AsNoTracking().ToListAsync();
        }

        public async Task<Produtos> GetById(string id)
        {
            return await _dataContext.Products.AsNoTracking().Include(x => x.Usuarios).Where(x => x.IdProduto == id).FirstOrDefaultAsync();
        }

        public async Task Create(Produtos produtos)
        {
            await _dataContext.Products.AddRangeAsync(produtos);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Produtos produtos)
        {
            _dataContext.Update(produtos);
            _dataContext.Entry(produtos).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(Produtos produtos)
        {
            _dataContext.Remove(produtos);
            await _dataContext.SaveChangesAsync();
        }
    }
}
