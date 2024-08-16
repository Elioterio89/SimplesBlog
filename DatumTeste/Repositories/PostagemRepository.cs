using BlogDatum.Data;
using BlogDatum.Data.Migrations;
using BlogDatum.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogDatum.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly BlogDatumContext _context;

        public PostagemRepository(BlogDatumContext context)
        {
            _context = context;
        }

        public void Adicionar(Postagem pPostagem)
        {
            _context.Postagens.Add(pPostagem);
            _context.SaveChanges();
        }

        public void Editar(Postagem pPostagem)
        {
            _context.Postagens.Update(pPostagem);
            _context.SaveChanges();
        }

        public void Excluir(Postagem pPostagem)
        {
            _context.Postagens.Remove(pPostagem);
            _context.SaveChanges();
        }

        public Postagem GetPostagemPorId(int pId)
        {
            return _context.Postagens.Find(pId);
        }

        public async Task<IEnumerable<Postagem>> GetPostagens()
        {
           return _context.Postagens.ToList();
        }
    }
}
