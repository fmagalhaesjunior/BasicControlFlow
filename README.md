# 📦 BasicControlFlow - Cadastro de Produtos e Clientes

Sistema ASP.NET Core com API RESTful, Razor Pages, SQL Server, Entity Framework Core e CI/CD com Azure DevOps.  
Este projeto é parte de um desafio prático de desenvolvimento de sistemas.

---

## 🚀 Funcionalidades

- Cadastro de clientes e produtos
- Listagem com paginação e filtros via API
- Interface com Razor Pages
- API RESTful com Swagger
- Persistência com SQL Server (via EF Core)
- Testes automatizados com xUnit
- Pipeline CI/CD no Azure DevOps
- Docker Compose para ambiente local

---

## 📁 Estrutura do Projeto

```
/src
  ├── BasicControlFlow.Domain
  ├── BasicControlFlow.Application
  ├── BasicControlFlow.Infrastructure
  └── BasicControlFlow.Web
/docker-compose.yml
/Dockerfile
/azure-pipelines.yml
```

---

## ⚙️ Como rodar localmente com Docker

> Requisitos:
> - Docker e Docker Compose instalados

### 📦 Subir API + SQL Server

```bash
docker-compose up --build
```

Acesse a aplicação em:  
📎 http://localhost:5000

---

## 📌 Banco de Dados

- Banco usado: **SQL Server**
- Criado automaticamente ao rodar a aplicação (via `EF Core Migrations`)
- String de conexão definida em `appsettings.Development.json`

---

## 🧪 Executar testes

```bash
dotnet test
```

---

## 🔄 Pipeline CI/CD (Azure DevOps)

- Disparado automaticamente ao fazer `push` na branch `release02`
- Etapas:
  - Build da aplicação
  - Execução dos testes unitários
  - Deploy simulado em uma pasta (drop)

Arquivo de configuração: [`azure-pipelines.yml`](./azure-pipelines.yml)

---

## 🧠 Dicas para Contribuição

1. Clone o projeto
2. Suba a stack com Docker:
   ```bash
   docker-compose up --build
   ```
3. Rode migrations localmente (caso necessário):
   ```bash
   dotnet ef database update -p src/BasicControlFlow.Infrastructure -s src/BasicControlFlow.Web
   ```
4. Crie novas features em branches a partir de `main` ou `release02`

---

## 📄 SQL - Scripts relevantes

### Top 5 clientes mais recentes
```sql
SELECT TOP 5 * FROM Clientes ORDER BY DataCadastro DESC;
```

### Procedure: pedidos por cliente
```sql
EXEC sp_ObterPedidosPorCliente @ClienteId = 'GUID';
```

### Atualizar email por ID
```sql
UPDATE Clientes SET Email = 'novo@dominio.com' WHERE Id = 'GUID';
```

### View de resumo
```sql
SELECT * FROM vw_ResumoClientes;
```

---

## 🛠 Tecnologias Usadas

- ASP.NET Core 8
- Razor Pages
- API RESTful
- Entity Framework Core
- SQL Server
- xUnit
- Moq
- Docker
- Azure DevOps Pipelines

---

## 📬 Contato

Caso tenha dúvidas ou sugestões, entre em contato por [email@exemplo.com].