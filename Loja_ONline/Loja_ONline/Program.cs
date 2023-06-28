using Loja_ONline.Infra;
using Loja_ONline.Service;
using Loja_ONline.Service.Interface;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Loja_ONline Swagger",
        Description = "Documentação da Api da Loja_ONline"
    });
});

#region [Dependency Injection]
builder.Services.AddScoped<IPerfilUsuarioRepository, PerfilUsuarioRepository>();

builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();

builder.Services.AddScoped<IVendasService, VendasService>();
builder.Services.AddScoped<IVendasRepository, VendasRepository>();
#endregion

#region [DataBase]
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("DatabaseSettings:ConnectionString").Value));
builder.Services.AddTransient<DataContext>();
#endregion

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
