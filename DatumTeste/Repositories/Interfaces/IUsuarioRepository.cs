using BlogDatum.Data.Migrations;

namespace BlogDatum.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioPorId(int pId);
        Usuario GetUsuariPorLogin(string pPogin);
        void Adcionar(Usuario pUsuario);
    }
}
