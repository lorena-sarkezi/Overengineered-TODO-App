using Todo.Azure.DependencyInjection;
using Todo.Base.DependencyInjection;
using Todo.Infrastructure.DependencyInjection;
using NextjsStaticHosting.AspNetCore;
using Todo.Application.DependencyInjection;
using Todo.Repository.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

#region Add Services

builder.Services.AddDatabaseOptions(builder.Configuration);
builder.Services.AddDatabase();
builder.Services.AddAzureInfrastructure();
builder.Services.AddAzureServices();
builder.Services.AddServices();
builder.Services.AddRepositories();


builder.Services.Configure<NextjsStaticHostingOptions>(builder.Configuration.GetSection("NextjsStaticHosting"));
builder.Services.AddNextjsStaticHosting();

#endregion Add Services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapNextjsStaticHtmls();
app.UseNextjsStaticHosting();

app.Run();