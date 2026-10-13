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


#if !DEBUG
builder.Services.Configure<NextjsStaticHostingOptions>(builder.Configuration.GetSection("NextjsStaticHosting"));
builder.Services.AddNextjsStaticHosting();
#endif


#endregion Add Services

var app = builder.Build();

// TODO: if any more app initialisation steps are needed (very likely), move them all to a dedicated service or something like ITodoApplication, with support for DI
await app.Services.MigrateDatabaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

#if !DEBUG
app.MapNextjsStaticHtmls();
app.UseNextjsStaticHosting();
#endif


app.Run();