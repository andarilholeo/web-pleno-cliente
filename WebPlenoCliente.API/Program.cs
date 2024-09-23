using WebPlenoCliente.Application;
using WebPlenoCliente.Application.Services.Cliente;
using WebPlenoCliente.Application.Services.EnderecoService;
using WebPlenoCliente.Application.ServicosExternos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("MySQLConnection"));

builder.Services.AddHttpClient<IApiViaCEP, ApiViaCep>(client =>
{
    var configuration = builder.Configuration;
    var baseUrl = configuration.GetSection("ApiSettings:BaseAPIViaCep").Value;
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IApiViaCEP, ApiViaCep>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
