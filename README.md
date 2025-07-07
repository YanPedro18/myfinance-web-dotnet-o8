# MyFinance Web App

Este é um aplicativo web para gerenciamento financeiro pessoal, desenvolvido com .NET 8 e ASP.NET Core. Ele permite aos usuários acompanhar suas transações, gerenciar planos de conta e ter uma visão clara de suas finanças.

## Descrição do Projeto

O MyFinance Web App é uma solução para ajudar indivíduos a controlar suas despesas e receitas. Através de uma interface intuitiva, o usuário pode cadastrar transações, organizar suas contas em um plano de categorias e visualizar relatórios básicos de sua saúde financeira. O foco é na simplicidade e eficácia para o controle financeiro diário.

## Arquitetura

O projeto adota uma arquitetura em **N-Camadas (N-Tiered Architecture)**, com uma clara separação de responsabilidades para promover a manutenibilidade, escalabilidade e testabilidade do código. A estrutura principal é dividida em:

* **Apresentação (Controllers & Views):**
    * **`Controllers/`**: Contém os controladores ASP.NET Core MVC que lidam com as requisições HTTP, orquestram a lógica da aplicação e interagem com a camada de Serviço. Eles atuam como a parte "Controller" do padrão **MVC**.
    * **`Views/`**: Armazena as views Razor (`.cshtml`) que são responsáveis pela renderização da interface do usuário. Representam a "View" do padrão **MVC**.
* **Aplicação/Serviço (`Services/`):**
    * **`Services/`**: Contém as interfaces (`I...Service.cs`) e implementações (`...Service.cs`) da lógica de negócio específica da aplicação. Esta camada atua como uma fachada para o domínio, orquestrando operações complexas e validando a entrada de dados. Ela faz uso extensivo de **Injeção de Dependência** para desacoplar-se da camada de Infraestrutura e adere ao **Princípio Aberto/Fechado (OCP)** e **Princípio da Segregação de Interfaces (ISP)** do SOLID.
* **Domínio (`Domain/`):**
    * **`Domain/`**: É o coração da aplicação, contendo as entidades de negócio (`PlanoConta.cs`, `Transaction.cs`) e a lógica de negócio central (agregações, validações de negócio, etc.). Esta camada é independente de tecnologias externas e representa o "Model" de negócio do padrão **MVC**. Segue o **Princípio da Responsabilidade Única (SRP)** do SOLID, focando apenas na lógica de negócio.
* **Infraestrutura (`Infrastructure/`):**
    * **`Infrastructure/`**: Responsável por detalhes técnicos e externos, como acesso a banco de dados.
    * **`MyFinanceDbContext.cs`**: Implementa o `DbContext` do Entity Framework Core, atuando como a unidade de trabalho e o repositório para acesso aos dados do banco. Representa a persistência de dados. Esta camada adere ao **Princípio da Inversão de Dependência (DIP)** do SOLID, sendo a camada de "detalhes" que depende de abstrações (suas entidades de domínio).

### Padrões de Design e Princípios SOLID Utilizados:

* **MVC (Model-View-Controller):** Padrão de arquitetura para a camada de apresentação, dividindo a aplicação em Model (Domínio/ViewModels), View (Razor Pages) e Controller.
* **SOLID Principles:** Conjunto de cinco princípios de design de software que guiam a criação de código flexível e sustentável. São observados na separação de responsabilidades, uso de interfaces e na estrutura geral do projeto.
* **Injeção de Dependência (Dependency Injection - DI):** Um padrão de design que permite que as dependências de uma classe sejam fornecidas externamente, em vez de criadas pela própria classe. Fundamental para o desacoplamento e testabilidade, visível pelo uso de interfaces de serviço.
* **Padrão de Serviço:** A camada `Services` encapsula a lógica de negócio, orquestrando operações e servindo como uma fachada para a funcionalidade do domínio.
* **Entity Framework Core (EF Core):** Utilizado como ORM (Object-Relational Mapper) para interagir com o banco de dados. O `DbContext` do EF Core implementa implicitamente os padrões **Unit of Work** e **Repository**.


## Tecnologias

* **Backend:**
    * .NET 8
    * ASP.NET Core MVC
    * Entity Framework Core
    * [**SQL Server**]
* **Frontend:**
    * HTML5
    * CSS3
    * JavaScript
    * Bootstrap
    * Razor Views
* **Ferramentas:**
    * Visual Studio (ou VS Code)
    * Git (para controle de versão)

## Como Configurar para Startup do Projeto

Siga os passos abaixo para configurar e rodar o projeto em seu ambiente local:

### Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [**SEU SGBD**] (e ferramentas de linha de comando/GUI, se necessário)
* [Git](https://git-scm.com/downloads)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) (Recomendado) ou [VS Code](https://code.visualstudio.com/)

### Passos de Configuração

1.  **Clone o repositório:**

    ```bash
    git clone [https://github.com/seu-usuario/myfinance-web-app.git](https://github.com/seu-usuario/myfinance-web-app.git)
    cd myfinance-web-app
    ```

2.  **Configurar a String de Conexão do Banco de Dados:**

    * Abra o arquivo `appsettings.json` (e `appsettings.Development.json` para o ambiente de desenvolvimento).
    * Atualize a string de conexão para apontar para o seu banco de dados local.

    ```json
    // appsettings.Development.json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=MyFinanceDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
        // Exemplo para SQL Server. Adapte para seu SGBD (PostgreSQL, SQLite, etc.)
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      }
    }
    ```
    **Lembre-se de criar o banco de dados `MyFinance` no seu SGBD local, se ainda não existir.**

3.  **Aplicar Migrações do Banco de Dados (Entity Framework Core):**

    * Navegue até a pasta que contém o arquivo `.csproj` do projeto (geralmente a raiz do seu repositório clonado, onde está `myfinance-web-dotnet-08.csproj`).
    * Abra o terminal (PowerShell, CMD, Bash) nessa pasta.
    * Execute os seguintes comandos para criar o banco de dados e as tabelas com base nas migrações:

    ```bash
    dotnet ef database update
    ```
    * Se for a primeira vez e você ainda não tiver migrações criadas, talvez precise executar:
        ```bash
        dotnet ef migrations add InitialCreate
        dotnet ef database update
        ```

4.  **Rodar a Aplicação:**

    * No mesmo terminal, execute:

    ```bash
    dotnet run
    ```

    * Alternativamente, se estiver usando **Visual Studio**:
        * Abra o arquivo de solução (`myfinance-web-dotnet-08.sln`).
        * Pressione `F5` ou clique no botão "IIS Express" (ou nome do projeto) para iniciar a depuração.

5.  **Acessar a Aplicação:**

    * Após o `dotnet run` (ou `F5` no Visual Studio), o console indicará o endereço onde a aplicação está rodando, geralmente:
        `http://localhost:5000` (HTTP) ou `https://localhost:5001` (HTTPS).
    * Abra seu navegador e acesse um desses endereços.

## Contribuindo

Se você deseja contribuir para este projeto, por favor, faça um fork do repositório, crie uma branch para sua feature e envie um Pull Request.

## Licença

Este projeto está licenciado sob a [Nome da Licença, ex: MIT License] - veja o arquivo [LICENSE.md](LICENSE.md) para detalhes.

---
