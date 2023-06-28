namespace Loja_ONline.Infra.Repositories.Interface
{
    public interface IPerfilUsuarioRepository
    {
        Task<string> Get_Id_Perfil_Usuario();
    }
}
