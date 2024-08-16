using BlogDatum.Data;
using BlogDatum.Data.Migrations;
using BlogDatum.Repositories.Interfaces;

namespace BlogDatum.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BlogDatumContext _context;

        public UsuarioRepository(BlogDatumContext context)
        {
            _context = context;
        }

        public void Adcionar(Usuario pUsuario)
        {
            _context.Usuarios.Add(pUsuario);
            _context.SaveChanges();

        }

        public Usuario GetUsuarioPorId(int pId)
        {
            return  _context.Usuarios.Find(pId);
        }

        public Usuario GetUsuariPorLogin(string pPogin)
        {
           return  _context.Usuarios.FirstOrDefault(u => u.Login == pPogin);
        }
    }
}
