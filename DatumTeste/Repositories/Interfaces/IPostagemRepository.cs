using BlogDatum.Data.Migrations;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace BlogDatum.Repositories.Interfaces
{
    public interface IPostagemRepository
    {
        Postagem GetPostagemPorId(int pId);
        Task<IEnumerable<Postagem>> GetPostagens();
        void Adicionar(Postagem pPostagem);
        void Editar(Postagem pPostagem);
        void Excluir(Postagem pPostagem);
    }
}
