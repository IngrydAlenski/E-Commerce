# Interfaces
 1 criar uma interface sempre com o I no começo do nome 
 2 metodos criar crud
 ## ordem dos metodos
 listar 
 buscar por id
 cadastrar 
 atualizar
 deletar 
 # Repository
 1 criar o repositotory
 2 herda da interface 
 3 implementar a inteface
 4  criar a variavel contexto e injetar o contexto 
 5 implementa o metodo de listar 
 6 implementa o metodo de cadastrar 
# Program
1  configurar a injeção da dependencia ADDTransient 
# Controller 
1 criar os controlers 
injetar o repository 
2 herda 
3criar metodos crud - listar - cadastrar - deletar - editar - 
4 configurar Swagger 
5 Localizar o endereço com HTTP depois informar o verbo
6 para cadastrar IActionResult nomedo repositoy que se encontra o "Cadastrar" declarando a variavel dentro dos parenteses 
6 retornar com o codigo se der certo ou não 
