using Loja_ONline.Entities;
using Loja_ONline.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja_ONline.Infra.Repositories
{
    public class VendasRepository : IVendasRepository
    {
        private readonly DataContext _dataContext;

        public VendasRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Vendas>> GetAll()
        {
            return await _dataContext.Vendas
                .Include(x => x.Produtos)
                .Include(x => x.Produtos.Usuarios)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Vendas> GetById(string id)
        {
            return await _dataContext.Vendas
                .Include(x => x.Produtos)
                .Include(x => x.Produtos.Usuarios)
                .Where(x => x.IdVenda == id)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Vendas venda)
        {
            await _dataContext.Vendas.AddAsync(venda);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Vendas venda)
        {
            _dataContext.Update(venda);
            _dataContext.Entry(venda).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(Vendas venda)
        {
            _dataContext.Vendas.Remove(venda);
            await _dataContext.SaveChangesAsync();
        }
    }
}
