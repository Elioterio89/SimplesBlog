namespace BlogDatum.Data.Migrations
{
    public class Postagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public DateTime DataCriacao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
