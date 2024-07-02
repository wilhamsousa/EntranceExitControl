# Controle de entrada e saída de veículos
Api para avaliação

🚀 Começando
Realize o download do projeto ou realize a clonagem

📋 Pré-requisitos
.Net 8

🔧 Instalação

- No Visual Studio abrir a solução EntranceExitControl.sln
- Acessar o arquivo "appsettings" dentro do projeto Gestran.VehicleControl.Api
- Editar a connection string com o banco de dados na propriedade "DefaultConnection"
- Realizar o Build da solução
- Marcar o projeto "Gestran.VehicleControl.Api" como "Default" e executar a aplicação em https.
- Acessar o swagger para testes em https://localhost:7049/swagger/index.html
- Obs.: Remover o Id do payload nas chamadas dos métodos "Persist" (Criar/atualizar)
    Exemplo de Request body em "User\persist": 
    {
      "name": "User 1"
    }


🛠️ Arquitetura
Api Rest
Clean Arquiteture

🛠️ Técnicas
Clean code
SOLID
DDD - Domain Driven Design

🛠️ Padrões
Fluent Validation
Repository

✒️ Autor
Wilham Ezequiel de Sousa

📄 Licença
MIT
