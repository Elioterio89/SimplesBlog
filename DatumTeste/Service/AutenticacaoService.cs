using BlogDatum.Data.Migrations;
using BlogDatum.Models;
using BlogDatum.Repositories.Interfaces;
using BlogDatum.Services.Interfaces;

namespace BlogDatum.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AutenticacaoService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario Autenticar(string pLogin, string pSenha)
        {          
            try
            {
                var oUsuario = _usuarioRepository.GetUsuariPorLogin(pLogin);
                if (oUsuario == null || oUsuario.Senha != pSenha)
                {
                    Console.WriteLine("Usuario não encontrado");
                    return null;
                }
                return oUsuario;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString(), "Erro ao buscar usuario");
                return null;
            }
        }

        public void Registrar(RegistroModel pUsuario)
        {
            try
            {
                var oUsuario = new Usuario
                {
                    Login = pUsuario.Username,
                    Senha = pUsuario.Password
                };
                _usuarioRepository.Adcionar(oUsuario);
            }
            catch (Exception ex)
            {   
                Console.WriteLine(ex.ToString(),"Usuario não registrado");
            }
          
        }
    }
}
