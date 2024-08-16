using BlogDatum.Data.Migrations;
using BlogDatum.Models;
using Microsoft.Extensions.Hosting;

namespace BlogDatum.Services.Interfaces
{
    public interface IPostagemService
    {
        Task<Postagem> NovaPostagem(PostagemModel pPostagem);
        void AlterarPostagem(Postagem pPostagem);
        void DeletarPostagem(int pId);
        Task<IEnumerable<Postagem>> GetAllPostagens();

        Postagem ObterPostagem(int pId);
    }
}
