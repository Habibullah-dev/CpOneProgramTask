using Microsoft.Azure.Cosmos;
using ProgramTask.Middleware;
using ProgramTask.Services.Contracts;
using ProgramTask.Services.Repos;



var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddSingleton((serviceProvider) =>
{
    var endpoint = configuration["CosmoSettings:Endpoint"];
    var primaryKey = configuration["CosmoSettings:PrimaryKey"];
    var databaseName = configuration["CosmoSettings:DatabaseName"];

    var cosmoClientOptions = new CosmosClientOptions()
    {
        ApplicationName = databaseName,
        ConnectionMode = ConnectionMode.Direct
    };

    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();

    });

    var cosmosClient = new CosmosClient(endpoint, primaryKey, cosmoClientOptions);

    return cosmosClient;
});

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

builder.Services.AddScoped<IProgramRepository, ProgramRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CosmosMiddleware>();

app.MapControllers();

app.Run();
