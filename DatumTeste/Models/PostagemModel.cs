namespace BlogDatum.Models
{
    public class PostagemModel
    {
        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public string? UsuarioId { get; set; }
        
    }
}
