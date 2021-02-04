<body>
<H1> # testeWEBAPIAlter </H1>

<H3> O Projeto </H3>
 
<p>O projeto consiste em uma WEB API .Net Core 3.1, inicialmente desenvolvida no VSCode, mas que acabei conseguindo fazer funcionar abrindo o projeto pelo Visual Studio 2019.</p>

<span><img style="max-width:50%; max-height:50%;" src="https://github.com/gabrielsouza95/testeWEBAPIAlter/blob/master/primeiro_teste_bem_sucedido.PNG" alt="Primeiro teste bem sucedido">
</span>

<p>Após muito perder a paciência tentando entender porque a aplicação não rodava, pois ao dar Run na aplicação pelo VSCode, apenas abria uma janela que continha um 'err_connection_refused'. Instalei uma extensão chamada "Live Server" que apenas me confundiu mais achando que havia feito progresso.</p>

<p>Após muitas horas de frustação e um tutorial de WEB API feito direto no Visual Studio 2019, que também não funcionou, um amigo que me ajudou sugeriu abrir o projeto do VSCode pelo Visual Studio 2019, pois poderia ser que o VSCode estivesse inicializando de forma errada o projeto.</p>

<p>Na tentativa de abrir o projeto pelo Visual Studio 2019, quando colocado para rodar a aplicação, já não dava mais o erro, mas ainda abria no local incorreto, utilizando uma rota do projeto modelo que fica mas que já havia sido apagado. Após algumas tentativas no Postman, meu amigo reparou que havia um erro de SSL e desligou a autenticação de SSL no settings da request e finalmente funcionou.</p>

<p>Depois disso, consegui começar a fazer as outras partes do projeto.</p>

</body>
