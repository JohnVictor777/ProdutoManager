# ProductManager - Sistema de Gestão de Produtos/Fornecedores

[![Licença MIT](https://img.shields.io/badge/Licença-MIT-blue.svg)](LICENSE.txt)
[![.NET Framework 4.7.2](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple.svg)](https://dotnet.microsoft.com)
[![MySQL Connector](https://img.shields.io/badge/MySQL-Connector%209.2.0-orange.svg)](https://dev.mysql.com)

Sistema desktop completo para gestão de produtos e fornecedores desenvolvido em C# com Windows Forms e MySQL.

## 🖼️ Demonstração

| Menu Principal | Cadastro de Fornecedores | Gestão de Produtos |
|---------------|-------------------------|-------------------|
| ![Menu](https://github.com/user-attachments/assets/95ce12b5-38f7-48bc-8028-62cae60f3e7f) | ![Fornecedores](https://github.com/user-attachments/assets/3945cafe-2ca4-4610-af20-fe253b9e1304) | ![Produtos](https://github.com/user-attachments/assets/d8094e81-de68-472f-946e-6880939670af) |

## ✨ Funcionalidades

### 📦 Gestão de Produtos
- Cadastro completo com preço e estoque
- Vinculação inteligente com fornecedores
- Controle de inventário em tempo real

### 🏢 Módulo de Fornecedores
- Cadastro com validação de CNPJ
- Endereço completo com CEP automático
- Múltiplos canais de contato

## 🛠️ Stack Tecnológica

```bash
├── Plataforma: .NET Framework 4.7.2
├── Interface: Windows Forms
├── Banco de Dados: MySQL 8.0+
├── ORM: MySQL Connector/NET 9.2
└── Arquitetura: Camadas (DAO, Model, View)
```

## ⚡ Configuração Rápida

### Pré-requisitos
- Visual Studio 2022+
- MySQL Server 8.0+
- .NET Framework 4.7.2 SDK

### 🚀 Primeiros Passos
1. Clone o repositório:
```bash
git clone https://github.com/JohnVictor777/ProdutoManager.git
```

2. Configure o banco de dados:
- Execute o [script de criação](https://docs.google.com/document/d/1IFDX8xYWDt4Xa1WtkE-ARwYAm4Tdo_YVHscKnaVmebw/edit?usp=sharing)

3. Configure a conexão:
```xml
<!-- App.config -->
<connectionStrings>
  <add name="bdprodutos" 
       connectionString="server=localhost;user id=SEU_USUARIO;password=SUA_SENHA;database=BDPRODUTOS"
       providerName="MySql.Data.MySqlClient"/>
</connectionStrings>
```

4. Restaure as dependências:
```bash
nuget restore
```

## 🏗️ Estrutura do Código

```
ProdutoManager/
├── br.com.project.conexao/  # Conexão com banco de dados
├── br.com.project.dao/      # Operações CRUD
├── br.com.project.model/    # Entidades de negócio
├── br.com.project.view/     # Interfaces gráficas
├── App.config               # Configurações locais
└── ProdutoManager.sln       # Solução principal
```

> ⚠️ **Importante**: Adicione `App.config` ao seu `.gitignore` para segurança

## Como Contribuir

1. Faça um fork do projeto
2. Crie uma branch (`git checkout -b feat/nova-funcionalidade`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feat/nova-funcionalidade`)
5. Abra um Pull Request

## 📄 Licença

Distribuído sob licença MIT. Consulte o arquivo [LICENSE.txt](LICENSE.txt) para mais informações.

## 📩 Contato

**John Victor**  
📧 victorjohn609@gmail.com  
📱 [@johnvic7or](https://instagram.com/johnvic7or)  
🔗 [GitHub Profile](https://github.com/JohnVictor777)
