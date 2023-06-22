using Loja_ONline.Entities;
using Loja_ONline.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja_ONline.Infra.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly DataContext _dataContext;

        public VendedorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    
        public async Task<List<Vendedores>> GetAll()
        {
            return await _dataContext.Vendedor.Include(x => x.Usuario).AsNoTracking().ToListAsync();
        }
    }
}
