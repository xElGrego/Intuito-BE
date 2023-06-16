using intuito.api.Extensions;
using intuito.api.Service;
using intuito.infrastructure.extentions;
using intuito.infrastructure.ioc;
using intuito.infrastructure.utils.Schema;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using veterinaria.yara.application.ioc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<EnumSchemaFilter>();
    options.MapType<TimeSpan>(() => new OpenApiSchema
    {
        Type = "string",
        Example = new OpenApiString("00:00:00")
    });
});

builder.Services.RegisterDependencies();
builder.Services.AddInfraestructure(builder.Configuration);

builder.Services.AddApplication();

//Se agregar grpc
builder.Services.AddGrpc();
builder.Services.AddGrpcHttpApi();


var app = builder.Build();

app.MapGrpcService<GreeterService>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseEndpoints(endpoints =>
//{
//     endpoints.MapGrpcService<GreeterService>();
//});

//Configurando HTTP request

app.ConfigureMetricServer();
app.ConfigureExceptionHandler();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
