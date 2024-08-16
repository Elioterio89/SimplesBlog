using BlogDatum.Data.Migrations;
using BlogDatum.Models;
using BlogDatum.Repositories.Interfaces;
using BlogDatum.Services.Interfaces;
using BlogDatum.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogDatum.Service
{
    public class PostagemService : IPostagemService
    {
        private readonly IPostagemRepository _postagemRepository;

        private readonly IHubContext<NotificationHub> _hubContext;

        private readonly ILogger<PostagemService> _logger;

        public PostagemService(IPostagemRepository postagemRepository , IHubContext<NotificationHub> hubContext , ILogger<PostagemService> logger)
        {
            _postagemRepository= postagemRepository;
            _hubContext = hubContext;
            _logger = logger;
        }
        public void AlterarPostagem(Postagem pPostagem)
        {

            _postagemRepository.Editar(pPostagem);
        }

        public void DeletarPostagem(int pId)
        {
            var post = _postagemRepository.GetPostagemPorId(pId);
            if (post != null)
            {
                _postagemRepository.Excluir(post);
            }
        }

        public async Task<IEnumerable<Postagem>> GetAllPostagens()
        {

           return await _postagemRepository.GetPostagens();
        }

        public async Task<Postagem> NovaPostagem(PostagemModel pPostagem)
        {
            Postagem oPostagem = new Postagem();
            oPostagem.DataCriacao= DateTime.Now;
            oPostagem.Corpo = pPostagem.Corpo;
            oPostagem.Titulo = pPostagem.Titulo;
            oPostagem.UsuarioId = Convert.ToInt16(pPostagem.UsuarioId);

            _postagemRepository.Adicionar(oPostagem);
            _logger.LogInformation("Post created. Sending notification.");
         
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", $"Nova Postagem: {oPostagem.Titulo}");

            return oPostagem;
        }

        public Postagem ObterPostagem(int id)
        {
            var oPostagem = _postagemRepository.GetPostagemPorId(id);

            return oPostagem;
        }

    }
}
