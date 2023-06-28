using Loja_ONline.Entities;
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
            return await _dataContext.Usuarios.AsNoTracking().Include(x => x.PerfilUsuario).ToListAsync();
        }

        public async Task<Usuarios?> GetById(string id)
        {
            return await _dataContext.Usuarios.AsNoTracking().Include(x => x.PerfilUsuario).Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
        }

        public async Task Create(Usuarios usuario)
        {
            await _dataContext.Usuarios.AddAsync(usuario);
            _dataContext.SaveChanges();
        }

        public async Task Update(Usuarios usuario)
        {
            _dataContext.Update(usuario);
            _dataContext.Entry(usuario).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(Usuarios usuario)
        {
            _dataContext.Usuarios.Remove(usuario);
            await _dataContext.SaveChangesAsync();
        }
    }
}
