# DesafioDEV
# Tecnologias utilizadas
- C#, Oracle 11g
# Como usar
## Configurando API 
- Baixe a pasta DesafioDEV diretamente no botão de download do GitHub.
- Extraia o arquivo .zip para um diretório de sua escolha.
- Abra o visual studio.
- Vá em Arquivo > Abrir > Projeto/Solução e selecione o diretório que foi extraido o projeto.
- Após abrir o projeto procure a pasta DataBase e abra a classe Connection.cs.
- Procure uma variável chamada connectinString e altere os seguites valores:
 - (HOST = Aqui você insere seu endereço IPV4),
 - (PORT = Aqui você insere a porta usada na base de dados),
 - User ID= Aqui você insere seu usuário do banco,
 - Password= Aqui você insere sua senha do banco.
- Salve as alterações usando CTRL + S.
## Configurando Banco de dados
- Abra o arquivo BaseDeDados.sql, copie os scripts.
- Execute o seu servidor do banco
- Abra uma conexão nova no seu SGDB, copie os scripts do arquivo BaseDeDados.sql, e cole no executor de script do seu SGDB.
- Execute este script e aguarde terminar, após o término a base de dados já estará instalada.
## Como testar
#### Executando via Visual Studio
 - Após abrir o projeto no visual studio procure o icone verde escrito DesafioDev.
 - Clique no icone e espere abrir uma janela do CMD, após isso está pronto para testar as rotas.
#### Executando via CMD
 - Abra o CMD (Tecla Windows + R, digite CMD e clique enter).
 - Após abrir o CMD acesse a pasta do projeto onde você extraiu.
 - Ex: cd C:\Users\public\Documents\Projeto DesafioDEV\DesafioDEV
 - Digite o comando dotnet run no CMD e clique enter.
 - Após aparecer textos na cor ver está pronto para testar as rotas.

#### Testando as rotas

- Abra o aplicativo de envio de requisições HTTP se sua preferência. Ex: PostMan.

#### Testando a rota Species

##### Método Post.
- Selecione o Post no aplicativo de envio de requisições HTTP.
- Insira essa rota: https://localhost:5001/species.
- Selecione o tipo de envio como Body depois Raw e o tipo de envio será JSON.
- Coloque estes dados no Raw:
  -  "description": "Myrciaria cauliflora"
- Clique em send estará salvo no banco de dados.  

##### Método Get.
- Selecione o Get no aplicativo de envio de requisições HTTP.
- Insira essa rota: https://localhost:5001/species/Myrciaria cauliflora. Obs: O final da rota é a descrição que deve buscar na tabela.
- Selecione o tipo de envio como None
- Clique em send e retornará os dados. 
 
#### Testando a rota Tree

##### Método Post.
- Selecione o Post no aplicativo de envio de requisições HTTP.
- Insira essa rota: https://localhost:5001/tree.
- Selecione o tipo de envio como Body depois Raw e o tipo de envio será JSON.
- Coloque estes dados no Raw:
  -  "description": "Jabuticabeira",
  -  "age" : 15,
  -  "species": "Myrciaria cauliflora"
- Clique em send estará salvo no banco de dados.  

##### Método Get.
- Selecione o Get no aplicativo de envio de requisições HTTP.
- Insira essa rota: https://localhost:5001/tree/Jabuticabeira. Obs: O final da rota é a descrição que deve buscar na tabela.
- Selecione o tipo de envio como None
- Clique em send e retornará os dados.  
 
#### Testando a rota Harvest

##### Método Post.
- Selecione o Post no aplicativo de envio de requisições HTTP.
- Insira essa rota: https://localhost:5001/harvest.
- Selecione o tipo de envio como Body depois Raw e o tipo de envio será JSON.
- Coloque estes dados no Raw:
  -  "information": "Colheita em SC",
  -  "tree": "Jabuticabeira",
  -  "date": "2021-04-23T10:00:00",
  -  "weigth": 150.0
- Clique em send estará salvo no banco de dados.  

##### Método Get.
- Selecione o Get no aplicativo de envio de requisições HTTP.
- Insira essa rota: https://localhost:5001/harvest/Colheita em SC. Obs: O final da rota é a informação que deve buscar na tabela.
- Selecione o tipo de envio como None
- Clique em send e retornará os dados.   

