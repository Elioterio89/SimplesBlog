# Blog com WebSocket

## Descrição

Crie um sistema básico de blog onde os usuários podem visualizar, criar, editar e excluir postagens. O projeto deve utilizar os princípios de orientação a objetos, seguir os princípios SOLID, integrar o Entity Framework para manipulação de dados e incluir uma comunicação simples usando WebSockets para notificar os usuários sobre novas postagens em tempo real.

## Requisitos Funcionais

- **Autenticação**: 
  - Usuários devem ser capazes de se registrar e fazer login.
  
- **Gerenciamento de Postagens**:
  - Usuários autenticados podem criar postagens, editar suas próprias postagens e excluir postagens existentes.
  
- **Visualização de Postagens**:
  - Qualquer visitante do site pode visualizar as postagens existentes.
  
- **Notificações em Tempo Real**:
  - Implemente um sistema de notificação em tempo real usando WebSockets para informar os usuários sobre novas postagens assim que são publicadas.

## Requisitos Técnicos

- Utilize a arquitetura monolítica, organizando as responsabilidades como autenticação, gerenciamento de postagens e notificações em tempo real.
- Aplique os princípios SOLID, especialmente o princípio da Responsabilidade Única (SRP) e o princípio da Inversão de Dependência (DIP).
- Utilize o Entity Framework para interagir com o banco de dados e armazenar informações sobre usuários e postagens.
- Implemente WebSockets para notificações em tempo real (notificação simples para a interface do usuário sempre que uma nova postagem é feita).

## Tecnologias

- **.NET 8 SDK**
- **SQL Server** (ou outro banco de dados compatível)

## Configuração do Projeto

### Clonar o Repositório

Clone o repositório usando o comando:

```bash
git clone git@github.com:Elioterio89/BlogDatum.git
cd [seu_repositorio]
```

Restaurar Dependências

```bash
dotnet restore
```

Configurar a String de Conexão

```
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BlogDb;User Id=sa;Password=123456789;"
}
```
Nota: Substitua User Id e Password pelos detalhes de conexão do seu ambiente local.


Aplicar Migrations
Execute os seguintes comandos para aplicar as migrations e criar o banco de dados:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Colocar os BlogDatum e o BlogClient para executar juntos

![image](https://github.com/user-attachments/assets/2602fb25-07c3-4513-9e88-199db52efd86)

Portas

  Em launchSettings configure pra rodar em "http://localhost:5003",





