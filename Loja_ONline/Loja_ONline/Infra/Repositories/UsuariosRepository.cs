using Loja_ONline.Entities;
using Loja_ONline.Entities.ViewModel.Produtos;
using Loja_ONline.Entities.ViewModel.Usuarios;
using Loja_ONline.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja_ONline.Infra.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly DataContext _dataContext;
        public UsuariosRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Usuarios>> GetAll()
        {
            return await _dataContext.Usuarios.AsNoTracking().ToListAsync();
        }
    }
}
