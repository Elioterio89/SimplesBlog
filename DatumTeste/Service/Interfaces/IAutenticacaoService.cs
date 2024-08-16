using BlogDatum.Data.Migrations;
using BlogDatum.Models;

namespace BlogDatum.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        Usuario Autenticar(string pLogin, string pSenha);
        void Registrar(RegistroModel pUsuario);
    }
}
