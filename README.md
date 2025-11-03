# ✅ ToDo List – Full Stack Application

Projeto desenvolvido para avaliação de habilidades Full Stack, contemplando backend em **.NET 8** e frontend em **Angular**, integrados a banco **SQL Server LocalDB**.

A solução utiliza arquitetura limpa, separação de responsabilidades, testes, notificações e boas práticas modernas para aplicações Web.

---

## 📌 Tecnologias Utilizadas

### 🖥 Backend
- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core
- SQL Server LocalDB
- Clean Architecture
- LINQ
- XUnit (Testes)
- Swagger/OpenAPI
- Dependency Injection

### 🎨 Frontend
- Angular 17+
- Standalone Components
- Angular Signals
- Reactive Forms
- CDK Drag & Drop (Kanban-style)
- Services + Observables
- Pipes
- CSS puro

---

## 🚀 Funcionalidades Implementadas
- Inserir uma tarefa nova
- Excluir uma tarefa
- Marcar tarefa como concluída (botão ou drag-and-drop)
- Listar todas as tarefas
- Notificações em tempo real (SignalR Hub preparado)
- Validações e UX aprimorada

---

## 📂 Estrutura do Projeto

```bash
todoworkspace/
├─ todo-backend/   # API .NET 8 (Clean Architecture, EF Core, SQL Server)
├─ todo-webapp/    # Aplicação Angular (Standalone Components, Signals)
└─ README.md       # Documentação principal

🧪 Executar Testes
cd todo-backend/Todo.Tests
dotnet test

💻 Frontend (Angular)
cd todo-webapp
npm install
ng serve --open
