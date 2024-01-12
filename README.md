# Projeto de Leitura e Salvamento de NFes
### Ao iniciar a aplicação, uma função automática criará as tabelas necessárias no banco de dados SQL Server.
Este projeto é uma aplicação desenvolvida utilizando a arquitetura DDD (Domain-Driven Design) e as tecnologias ASP.NET Core no backend, SQL Server como banco de dados e Razor no frontend. O objetivo principal é a leitura e o armazenamento de dados de Notas Fiscais Eletrônicas (NFes).
![image](https://github.com/WillianPrado/LeitorNFe/assets/65555067/5363ab3e-8445-4e06-8e28-a2636e6beddc)

## Pré-requisitos

- Certifique-se de ter o [ASP.NET Core](https://dotnet.microsoft.com/download) instalado na sua máquina.
- É necessário ter o [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) instalado e configurado.
- Adicione a string de conexão do banco de dados ao arquivo `appsettings.json` no projeto `LeitorNFe`.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "SuaStringDeConexaoAqui"
  },
  // Outras configurações...
}
```

## Instruções para Execução

1. Clone este repositório em sua máquina local.
2. Abra o projeto no Visual Studio.
3. Certifique-se de que o SQL Server esteja em execução.
4. Adicione a string de conexão do banco de dados ao arquivo `appsettings.json`.
5. Inicie a aplicação no Visual Studio.

## Estrutura do Projeto

- **LeitorNFe:** Contém o frontend da aplicação desenvolvido em Razor.
- **LeitorNFe.Domain:** Contém os objetos e regras de negócio da aplicação.
- **LeitorNFe.Infra:** Responsável pelo acesso ao banco de dados SQL Server.

## Funcionalidades

1. Leitura e salvamento de dados de Notas Fiscais Eletrônicas (NFes).
2. Arquitetura DDD para organização e manutenção do código.
3. Criação automática de tabelas no banco de dados ao iniciar a aplicação.

Sinta-se à vontade para explorar, contribuir e melhorar este projeto. Qualquer dúvida ou problema, não hesite em abrir uma [issue](https://github.com/seu-usuario/seu-repositorio/issues).
