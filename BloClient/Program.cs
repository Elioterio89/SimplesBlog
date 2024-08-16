using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

class BlogClient
{
    private static readonly HttpClient httpClient = new HttpClient();
    private static HubConnection connection;

    static async Task Main(string[] args)
    {
        var apiUrl = "http://localhost:5003/api";
        var hubUrl = "http://localhost:5003/notificationHub";

        connection = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .Build();

        connection.On<string>("ReceiveNotification", (message) =>
        {
            Console.WriteLine($"Notificação -> {message}");
        });

        await connection.StartAsync();
        Console.WriteLine("Conectado ao WebSocket.");

        string token = null;
        while (true)
        {
            Console.WriteLine("\n1. Registrar\n2. Logar\n3. Postar\n4. Editar Postagem\n5. Deletar Postagem\n6. Sair");
            Console.WriteLine("Escolha uma opção: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await RegisterUser(apiUrl);
                    break;
                case "2":
                    token = await LoginUser(apiUrl);
                    break;
                case "3":
                    if (token != null) await CreatePost(apiUrl, token);
                    else Console.WriteLine("Você precisa logar primeiro.");
                    break;
                case "4":
                    if (token != null) await EditPost(apiUrl, token);
                    else Console.WriteLine("Você precisa logar primeiro.");
                    break;
                case "5":
                    if (token != null) await DeletePost(apiUrl, token);
                    else Console.WriteLine("Você precisa logar primeiro.");
                    break;
                case "6":
                    Console.WriteLine("Saindo...");
                    await connection.DisposeAsync();
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    private static async Task RegisterUser(string apiUrl)
    {
        Console.Write("Digite seu nome de usuário: ");
        var username = Console.ReadLine();
        Console.Write("Digite sua senha: ");
        var password = Console.ReadLine();

        var response = await httpClient.PostAsJsonAsync($"{apiUrl}/Autenticacao/registrar", new { username, password });
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Usuário registrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Falha ao registrar o usuário.");
        }
    }

    private static async Task<string> LoginUser(string apiUrl)
    {
        Console.Write("Digite seu nome de usuário: ");
        var username = Console.ReadLine();
        Console.Write("Digite sua senha: ");
        var password = Console.ReadLine();

        var response = await httpClient.PostAsJsonAsync($"{apiUrl}/Autenticacao/logar", new { username, password });
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<JsonElement>();
            var token = result.GetProperty("token").GetString();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Console.WriteLine("Login bem-sucedido !");
            Console.WriteLine("Ola " + username);
            return token;
        }
        else
        {
            Console.WriteLine("Falha no login.");
            return null;
        }
    }

    private static async Task CreatePost(string apiUrl, string token)
    {
        Console.Write("Digite o título da postagem: ");
        var title = Console.ReadLine();
        Console.Write("Digite o conteúdo da postagem: ");
        var content = Console.ReadLine();

        var postagem = new
        {
            Titulo = title,
            Corpo = content
        };

        var response = await httpClient.PostAsJsonAsync($"{apiUrl}/Postagem", postagem);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Postagem criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Falha ao criar a postagem.");
        }
    }

    private static async Task EditPost(string apiUrl, string token)
    {
        Console.Write("Digite o ID da postagem a ser editada: ");
        var postId = Console.ReadLine();
        Console.Write("Digite o novo título: ");
        var title = Console.ReadLine();
        Console.Write("Digite o novo conteúdo: ");
        var content = Console.ReadLine();

        var postagem = new
        {
            Titulo = title,
            Corpo = content
        };

        var response = await httpClient.PutAsJsonAsync($"{apiUrl}/Postagem/{postId}", postagem);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Postagem editada com sucesso!");
        }
        else
        {
            Console.WriteLine("Falha ao editar a postagem.");
        }
    }

    private static async Task DeletePost(string apiUrl, string token)
    {
        Console.Write("Digite o ID da postagem a ser deletada: ");
        var postId = Console.ReadLine();

        var response = await httpClient.DeleteAsync($"{apiUrl}/Postagem/{postId}");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Postagem deletada com sucesso!");
        }
        else
        {
            Console.WriteLine("Falha ao deletar a postagem.");
        }
    }
}
