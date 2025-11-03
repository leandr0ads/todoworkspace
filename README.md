# ✅ ToDo List - Full Stack Application

A solução contempla:

- ✅ Backend em .NET 8 (Clean Architecture, REST API, EF Core, SQL)
- ✅ Frontend em Angular 17+ (Standalone Components, Signals, Forms)
- ✅ Banco SQL Server LocalDB
- ✅ Validações, UX aprimorada e boas práticas
- ✅ Testes unitários
- ✅ Suporte a notificações (SignalR Hub preparado)

## 🧱 Estrutura do Projeto

todoworkspace/
├─ todo-backend/ → API .NET 8 + Entity Framework Core
└─ todo-webapp/ → SPA Angular

---

## 🚀 Funcionalidades Implementadas

- Inserir uma tarefa nova
- Excluir uma tarefa
- Marcar uma tarefa como concluída (Ação de botão ou Drag and Drop)
- Listar todas as tarefas
- Notificações

---

## ✅ Tecnologias Utilizadas

### Backend
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Clean Architecture
- LINQ
- XUnit (testes)

### Frontend
- Angular 17+
- Standalone Components
- Angular Signals
- Angular Forms
- Pipes
- Services
- CSS puro
- CDK Drag&Drop

---

## ▶️ Como Rodar

### Backend

cd todo-backend
dotnet restore
dotnet ef database update
dotnet run

Testes
cd todo-backend/Todo.Tests
dotnet test

### Frontend

cd todo-webapp
npm install
ng serve --open

📦 Requisitos

.NET 8 SDK
Node.js 18+
Angular CLI
SQL Server LocalDB
