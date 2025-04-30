//CRUD 
//Create - Criar/Cadastrar
//Read - Ler
//Update - Atualizar 
//Delete - Deletar

//O .NET vai criar os objetos (Injecao de dependencias)

//ADDTransiente - O C# cria uma instancia nova, toda vez que uma metodo e chamado 

//ADDScoped - O C# cria uma instancia toda vez que um crontroller foi criado 

//ASSSingleton - 

using System.Text;
using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;
using Microsoft.IdentityModel.Tokens;

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


//Configuracao do token
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Eccomerce",
            ValidAudience = "Eccomerce",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Minha-chave-ultra-mega-secreta-senai"))
        };
    });
//Autorizar o usuario 
builder.Services.AddAuthentication();



var app = builder.Build();

//////////////////////////////////////////////
app.UseSwagger();
app.UseSwaggerUI();
//////////////////////////////////////////////

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();



