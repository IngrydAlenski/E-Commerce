//CRUD 
//Create - Criar/Cadastrar
//Read - Ler
//Update - Atualizar 
//Delete - Deletar

//O .NET vai criar os objetos (Injecao de dependencias)

//ADDTransiente - O C# cria uma instancia nova, toda vez que uma metodo e chamado 

//ADDScoped - O C# cria uma instancia toda vez que um crontroller foi criado 

//ASSSingleton - 

using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Linhas para fazer teste de todos os metodos 
builder.Services.AddSwaggerGen();
//////////////////////////////////////////////
///
builder.Services.AddDbContext<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IItemPedidoRepository,ItemPedidoRepository>();

var app = builder.Build();

//////////////////////////////////////////////
app.UseSwagger();
app.UseSwaggerUI();
//////////////////////////////////////////////

app.MapControllers();

app.Run();



