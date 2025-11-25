# 🛒 Gerenciador de Produtos API

API RESTful desenvolvida em **.NET 8** com foco em boas práticas de engenharia de software, demonstrando a aplicação prática de **Clean Architecture**, princípios **SOLID** e **Testes Automatizados**.

## 🚀 Tecnologias & Práticas

- **.NET 8** (LTS)
- **Clean Architecture** (Separação em Domain, Application, Infrastructure e API)
- **Entity Framework Core** com abordagem **Fluent API** (sem sujar o Domínio)
- **SQL Server** (LocalDB)
- **Injeção de Dependência** Nativa
- **Testes Unitários** com **xUnit** e **Moq**
- **Swagger/OpenAPI** para documentação
- **Design Patterns**: Repository, Unit of Work, DTOs (InputModels/ViewModels)

## 🏗️ Estrutura da Arquitetura

O projeto segue estritamente a Regra de Dependência:

1.  **Domain:** O núcleo da aplicação. Contém as Entidades (`Product`) e Interfaces (`IProductRepository`). Não possui dependências externas.
2.  **Application:** Contém os Casos de Uso (`ProductService`) e DTOs. Orquestra o fluxo de dados e regras de negócio.
3.  **Infrastructure:** Implementa o acesso a dados (EF Core) e configurações de banco.
4.  **API:** Ponto de entrada (Controllers), responsável apenas por receber requisições e devolver respostas HTTP.

## 🧪 Testes Unitários

O projeto inclui testes unitários para validar a Regra de Negócio (Camada Application), utilizando **Moq** para isolar o banco de dados e garantir testes rápidos e confiáveis.

## ▶️ Como Rodar

1.  Clone o repositório.
2.  Configure a string de conexão no `appsettings.json` (se necessário).
3.  Execute as migrations para criar o banco:
    ```bash
    dotnet ef database update -p GerenciadorProdutos.Infrastructure -s GerenciadorProdutos.API
    ```
4.  Execute a API:
    ```bash
    dotnet run --project GerenciadorProdutos.API
    ```
5.  Acesse o Swagger em `http://localhost:XXXX/swagger`.