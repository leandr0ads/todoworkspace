✅ ToDo List – Full Stack Application
Projeto desenvolvido para avaliação de habilidades Full Stack, contemplando backend em .NET 8 e frontend em Angular, integrados a banco SQL Server LocalDB.

A solução contempla:
✅ Backend em .NET 8 (Clean Architecture, REST API, EF Core, SQL)
✅ Frontend em Angular 17+ (Standalone Components, Signals, Forms)
✅ Banco SQL Server LocalDB
✅ Validações, UX aprimorada e boas práticas
✅ Testes unitários
✅ Suporte a notificações (SignalR Hub preparado)

🧱 Estrutura do Projeto
todoworkspace/
├─ todo-backend/   → API .NET 8 + Entity Framework Core
├─ todo-webapp/    → SPA Angular
└─ README.md       → (este arquivo)

🚀 Funcionalidades Implementadas
- Inserir uma tarefa nova
- Excluir uma tarefa
- Marcar uma tarefa como concluída (Ação de botão ou Drag and Drop)
- Listar todas as tarefas
- Notificações

✅ Tecnologias Utilizadas

🖥 Backend
.NET 8
ASP.NET Core Web API
Entity Framework Core
SQL Server LocalDB
Clean Architecture
LINQ
XUnit (testes)

🎨 Frontend
Angular 17+
Standalone Components
Angular Signals
Reactive Forms
Pipes
Services
CSS puro
CDK Drag & Drop

▶️ Como Rodar
🔌 Backend
cd todo-backend
dotnet restore
dotnet ef database update
dotnet run

Acesse a documentação via Swagger:
https://localhost:7115/swagger

🧪 Testes
cd todo-backend/Todo.Tests
dotnet test

💻 Frontend
cd todo-webapp
npm install
ng serve --open

Aplicação disponível em:
http://localhost:4200

📦 Requisitos
.NET 8 SDK
Node.js 18+
Angular CLI
SQL Server LocalDB
