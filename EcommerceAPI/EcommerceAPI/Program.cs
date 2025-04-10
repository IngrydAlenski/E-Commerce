//CRUD 
//Create - Criar/Cadastrar
//Read - Ler
//Update - Atualizar 
//Delete - Deletar

using EcommerceAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<EcommerceContext, EcommerceContext>();

var app = builder.Build();

app.MapControllers();

app.Run();

