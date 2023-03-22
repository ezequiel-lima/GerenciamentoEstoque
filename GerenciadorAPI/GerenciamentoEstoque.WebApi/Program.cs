using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.Infra;
using GerenciamentoEstoque.Infra.Data;
using GerenciamentoEstoque.WebApi.Services.Interfaces;
using GerenciamentoEstoque.WebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<GerenciamentoEstoqueDataContext>(options =>
    {
        options.UseSqlServer(connectionString, x => x.MigrationsAssembly("GerenciamentoEstoque.Infra"));
    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var services = GetServiceCollection(builder);
}

IServiceCollection GetServiceCollection(WebApplicationBuilder builder)
{
    // Adicionando serviços
    var services = builder.Services;
    services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    services.AddScoped<IReadRepository<Produto>, ApplicationRepository<Produto>>();
    services.AddScoped<IWriteRepository<Produto>, ApplicationRepository<Produto>>();
    services.AddScoped<IProdutoService, ProdutoService>();

    return services;
}