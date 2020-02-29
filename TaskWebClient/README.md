# TaskWebClient

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 8.3.21.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Intruções para inicializar o projeto:

verificar a connectionString dentro do AppSettings.json, está configurada para usar autenticação do windows

"DevConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskDB;Trusted_Connection=True;MultipleActiveResultSets=True;"

Substituir o primeiro parametro Server= para o nome do servidor da máquina que está rodando o projeto, ex minha máquina Server=(localdb)\MSSQLLocalDB

Autenticação SQL: usar autenticação windows

Para criar o banco de dados, abrir o Visual Studio, no Package Manager Console
selecionar como Default Project: Models 
em seguida, executar o comando update-database.

Neste momento o banco de dados será criado.

Executar o projeto no VS, e executar o projeto front-end utilizando o comando "npm start", ou comando de preferência.

## Tecnologias e padrões utilizados:

Projeto Backend e Frontend desacoplados

Solid

XUnit para testes unitários

C# .Netcore

Angular 8

Toastr para notificações web

Bootstrap

CleanCode

SQL Server

Mapper manual de entidade para Dto

.Net EntityFramework com migrations

IoC injeção de dependência nativa do .netCore com singleton, configurada no arquivo startup.cs.

CORS
