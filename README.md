# stone-challenge

## Framework utilizado
- .NET Core 2.2

## Instruções para Executar o Projeto
Caso a solução seja aberta utilizando o Visual Studio, um simples F5 deve bastar
para rodar o programa.

Se a preferência for pela linha de comando, execute no diretório raiz da solução:

    dotnet run -p .\WebAPI\WebAPI.csproj

O applicativo vai estar rodando em localhost:5000.

O endpoint pedido pode ser chamado em ***/api/employees/bonuses/{valor_do_bonus}***
utilizando-se um GET e passando-se o valor a ser distribuído pelos funcionários.

**Obs.:** *A primeira vez que o comando run for executado pode haver uma demora
devido ao restore dos pacotes.*

## Banco de Dados

O BD é um SQL Serve que já está pré-populado e hospedado na Azure.

Caso seja desejado usar um BD local, basta utilizar o SQL Server para criar o banco
e mudar a *connection string* no arquivo *appsettings.json*.

Em seguida, será necessário rodar as migrações. Para isso, basta executar o seguinte
comando a partir do diretório raiz da solução.

    dotnet ef database update -p .\Infrastructure.csproj -s ..\WebAPI\WebAPI.csproj

A primeira migração cria as tabelas, e a segunda popula o banco.

Por falta de tempo (e para facilitar os testes), optei por pré-popular o BD via
*migrations* ao invés de fazer um CRUD de funcionários.

## Testes

Para rodar os testes, basta executar no diretório raiz:

    dotnet test .\Tests\Tests.csproj
