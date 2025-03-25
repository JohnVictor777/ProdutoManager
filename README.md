# ProductManager - Sistema de Gestão de Produtos e Fornecedores

[![Licença MIT](https://img.shields.io/badge/Licença-MIT-blue.svg)](LICENSE.txt)
[![.NET Framework 4.7.2](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple.svg)](https://dotnet.microsoft.com)
[![MySQL Connector](https://img.shields.io/badge/MySQL-Connector%209.2.0-orange.svg)](https://dev.mysql.com)

Sistema desktop completo para gestão de produtos e fornecedores desenvolvido em C# com Windows Forms e MySQL.


## 📸 Demonstração Visual

--------

### Menu Principal
![Menu](https://github.com/user-attachments/assets/a52b4b7e-b49a-4f33-9c89-ec1e6ef7e4c5)  
*Interface inicial com acesso rápido a todas as funcionalidades: Cadastro de Produtos, Fornecedores e opção de Sair.*

--------

### Módulo de Fornecedores
![Tela de Fornecedores](https://github.com/user-attachments/assets/a3da13c9-116b-46b8-ab49-cbad37c1d4dc)  
*Formulário de cadastro com campos completos: CNPJ, telefone, endereço e dados de contato.*

-------

### Módulo de Produtos
![Tela de Produtos](https://github.com/user-attachments/assets/64bec728-207d-41be-a784-58523e35fd13)  
*Cadastro de produtos com vinculação a fornecedores, controle de preço e quantidade em estoque.*

-------

### Confirmação de Saída
![Diálogo de Confirmação](https://github.com/user-attachments/assets/e5e09ff4-ce89-4414-880d-63d86c8cba54)  
*Janela modal de confirmação com opções Sim/Não para evitar fechamento acidental.*

--------

## ✨ Funcionalidades

- 📦 **Gestão de Produtos**
  - Cadastro de produtos com detalhes (nome, preço, quantidade em estoque)
  - Categorização de produtos
  - Busca e filtro de produtos

- 🏢 **Integração com Fornecedores**
  - Cadastro de fornecedores
  - Vinculação de produtos a fornecedores
  - Controle de informações de contato
 
## 🛠️ Tecnologias Utilizadas

### 📌 Core Stack
- **Plataforma**: .NET Framework 4.7.2
- **Interface**: Windows Forms
- **Banco de Dados**: MySQL 5.7+
- **Arquitetura**: Padrão MVC
- **ORM**: MySQL Connector/NET 9.2.0

### 📦 Principais Dependências
```bash
<PackageReference Include="MySql.Data" Version="9.2.0" />
```
```bash
<PackageReference Include="System.Configuration.ConfigurationManager" Version="8.0.0" />
```
## 🛠️ Configuração do Ambiente
### Pré-requisitos

- Visual Studio 2022 (ou superior)
- .NET Framework 4.7.2 Developer Pack
- MySQL Server 5.7+

### Instalação
1. Clone o repositório:
   ```bash
   git clone https://github.com/JohnVictor777/ProductManager.git
   ```
2. Restaure os pacotes NuGet:

  ```bash
   nuget restore
  ```
3. Configure a conexão no App.config:
  ```bash
<connectionStrings>
  <add name="dbConnection" 
       connectionString="Server=localhost;Database=productmanager;Uid=root;Pwd=senha;"
       providerName="MySql.Data.MySqlClient"/>
</connectionStrings>
  ```
4. Execute a aplicação:
   ```bash
   cd ProductManager
   dotnet run
   ```

## 📂 Estrutura do Projeto
```
ProductManager/
├── br.com.project.conexao/     # Conexão com banco de dados
├── br.com.project.dao/         # Camada de acesso a dados
├── br.com.project.model/       # Entidades de negócio
├── br.com.project.view/        # Interface do usuário
├── docs/                       # Documentação
├── App.config                  # Configurações
└── ProductManager.sln          # Arquivo de solução
```

## Como Contribuir
Contribuições são bem-vindas! Siga estes passos:
1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/NovaFeature`)
3. Faça commit das mudanças (`git commit -m 'Adiciona nova feature'`)
4. Faça push para a branch (`git push origin feature/NovaFeature`)
5. Abra um Pull Request

## 📜 Licença
Distribuído sob licença MIT. Veja `LICENSE` para mais informações.

## 📬 Contato
Seu Nome - [@johnvic7or](https://instagram.com/johnvic7or) - victorjohn609@gmail.com

Link do Projeto: [https://github.com/JohnVictor777/ProductManager](https://github.com/JohnVictor777/ProductManager)
