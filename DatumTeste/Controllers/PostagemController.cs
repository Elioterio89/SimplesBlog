using BlogDatum.Data.Migrations;
using BlogDatum.Models;
using BlogDatum.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace BlogDatum.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PostagemController: ControllerBase
    {
        private readonly IPostagemService _postagemService;

        public PostagemController(IPostagemService postagemService)
        {
            _postagemService = postagemService;
        }


        [HttpGet]
        public IActionResult GetPostagens()
        {
            var posts = _postagemService.GetAllPostagens();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostagem([FromBody] PostagemModel Postagem)
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            if (usuarioId == null)
            {
                return Unauthorized();
            }
            Postagem.UsuarioId = usuarioId;
            var novaPostagem = await _postagemService.NovaPostagem(Postagem);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditarPostagem(int id, [FromBody] PostagemModel pPostagem)
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (usuarioId == null)
            {
                return Unauthorized();
            }

            var postagemExistente = _postagemService.ObterPostagem(id);
            if (postagemExistente == null || postagemExistente.UsuarioId.ToString().Trim() != usuarioId.Trim())
            {
                return NotFound();
            }

            postagemExistente.Corpo = pPostagem.Corpo;
            postagemExistente.Titulo = pPostagem.Titulo;
            _postagemService.AlterarPostagem(postagemExistente);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPostagem(int id)
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (usuarioId == null)
            {
                return Unauthorized();
            }

            var postagemExistente = _postagemService.ObterPostagem(id);
            if (postagemExistente == null || postagemExistente.UsuarioId.ToString() != usuarioId)
            {
                return NotFound();
            }

            _postagemService.DeletarPostagem(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPostagem(int id)
        {
            var postagem = _postagemService.ObterPostagem(id);
            if (postagem == null)
            {
                return NotFound();
            }

            return Ok(postagem);
        }

    }
}
