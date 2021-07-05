<h1 align="center">Projeto Back-end Developer - API Cálculo de Matragem</h1>
<h1 align="center">
    <img src="https://user-images.githubusercontent.com/13840069/124410085-09eab200-dd20-11eb-9532-1538e0e2642b.png" width="40" height="30">
    </img>
</h1>
<p align="left">Este projeto tem por base disponibilizar duas Web Api feitas em asp.net core versão 3.1</p>
<p align="left">O que encontraremos nesse projeto:</p>
<ol class="inside square">
    <li> 2 API:
        <ol class="inside square">
            <li>API1 - Retorna o valor fixo do metro quadrado no Endpoint:https://url:{porta}/api/Metragem/CalculaValorMetro</li>
            <li>API2 - Recebe quantidade de metros quadrados e calcula o valor do imóvel no Endpoint: https://url:{porta}/api/Metragem/CalculaValorImovel</li>
        </ol>
    </li>
    <li>Boa praticas em desenvolvimento.</li>
    <li>Padrões de codificação.</li>
    <li>Execução do projeto suportado em Docker no ambiente Linux como container.</li>
    <li>Suporte ao Swagger: https://url:{porta}/swagger/index.html ou  https://metragemmvc.herokuapp.com/swagger/index.html.</li>
    <li>Testes unitários e teste de integração.</li>
    <li>Integeração continua e integra continua (CICD), configurado e disponibilizado pelo Heroku.</li>
    <li>Disponibilização da aplicação para teste no heroku na url : https://metragemmvc.herokuapp.com/swagger/index.html.</li>
</ol>
</br>
<p align="left"><b>ATENÇÃO!</b></p>
<p align="left"><b>Todo projeto foi feito e executado em plataforma Windows.</b></p>
<p align="left">Para rodar esse projeto siga os passos a seguir:</p>
<p align="left">1. Para rodar esse projeto é necessário ter o Visual Studio ou Visual Studio Code instalado.</p>
<p align="left">2. Com o VS instalado você pode clonar o projeto no github executando o camando: </p>

```sh
git clone gh repo clone alanraysilva/MetragemCore 
```
<p align="left"> Ou fazendo o download:</p>

```sh
https://github.com/alanraysilva/MetragemCore.git 
```
<p align="left">3. Com o projeto baixado antes de executa-lo se atente para o arquivo DockerFile, existem dois arquivos um o arquivo DockerFile que irá conter o código para a criação do container por meio do prompt de comando e dentro do arquivo DockeFile1.original, terá os comandos para executar em modo debug, sendo assim caso queira compilar o código em modo debug copie e cole todo o conteudo do arquivo DockerFile1.original para dentro do arquivo DockerFile e assim sucessivamente.</p>
<p align="left"><b>Essa ação acima é necessária, porque quando desenvolvido pelo Visual Studio o que aconteceu, a IDE gera sua própria codificação do DockerFile, porém essa codificação não consegue ser executada em modo prompt, ocorre quando executado a ação docker built -t o docker gera erro na criação do container, contudo a Microsoft tem um comando auxiliar o dotnet msbuild MetragemCore.csproj /t:ContainerBuild /p:Configuration=Release, que executa a mesma ação do docker build, entretando o mesmo não é satisfatório para criar as outras ações necessárias como subir no DockerHub e Heroku </b></p>
<p align="left">4. Esse código do github está vinculado a conta do Heroku proporcionando o deploy continuo.</p>
<p align="left">5. Parar fazer o download do container no DockerHub, para testar a api em funcionamento sem necessidade de compilação: </p>

```sh
docker pull alanraysilva/metragemmvc:2.0
```

<p align="left">6. Parar fazer o teste a api em funcionamento no Heroku: </p>

```sh
https://metragemmvc.herokuapp.com/swagger/index.html.
```

