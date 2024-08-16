using Microsoft.Extensions.Hosting;

namespace BlogDatum.Data.Migrations
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public ICollection<Postagem> Postagens { get; set; }
    }
}
