using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace Loja_ONline.Infra.Repositories
{
    public class PerfilUsuarioRepository : IPerfilUsuarioRepository
    {
        private readonly DataContext _dataContext;
        public PerfilUsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Get_Id_Perfil_Usuario()
        {
            var perfil = Enum.GetName(PerfilUsuario.Usuario);
            var perfilEntity = await _dataContext.PerfilUsuarios.AsNoTracking().Where(x => x.Perfil == perfil).FirstOrDefaultAsync();

            return perfilEntity.IdPerfil;
        }
    }
}
