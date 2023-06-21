using Loja_ONline.Entities;
using Loja_ONline.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja_ONline.Infra.Repositories
{
    public class ProductsRepository : IProdutosRepository
    {
        private readonly DataContext _dataContext;

        public ProductsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Produtos>> GetAll()
        {
            return await _dataContext.Products
                .Include(x => x.Vendedores)
                .Include(x => x.Vendedores.Usuario)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
