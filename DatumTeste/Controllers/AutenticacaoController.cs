using BlogDatum.Data.Migrations;
using BlogDatum.Models;
using BlogDatum.Service.Interfaces;
using BlogDatum.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BlogDatum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;
        private readonly ITokenService _tokenService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService, ITokenService tokenService)
        {
            _autenticacaoService = autenticacaoService;
            _tokenService = tokenService;
        }

        [HttpPost("logar")]
        public IActionResult Logar([FromBody] LoginModel model)
        {
            var user = _autenticacaoService.Autenticar(model.Username, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.GerarToken(user.Id.ToString());
            return Ok(new { Token = token });
        }

        [HttpPost("registrar")]
        public IActionResult Registar([FromBody] RegistroModel model)
        {

            _autenticacaoService.Registrar(model);
            return Ok();       
        }
    }
}
