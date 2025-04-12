//CRUD 
//Create - Criar/Cadastrar
//Read - Ler
//Update - Atualizar 
//Delete - Deletar

using EcommerceAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Linhas para fazer teste de todos os metodos 
builder.Services.AddSwaggerGen();
//////////////////////////////////////////////
///
builder.Services.AddTransient<EcommerceContext, EcommerceContext>();

var app = builder.Build();

//////////////////////////////////////////////
app.UseSwagger();
app.UseSwaggerUI();
//////////////////////////////////////////////

app.MapControllers();

app.Run();

