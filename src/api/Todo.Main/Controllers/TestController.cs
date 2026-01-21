using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Base.Abstractions.Azure;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Entities;
using Todo.Entities.Models;

namespace Todo.Main.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IConnectionStringProviderFactory _connectionStringProviderFactory;
    private readonly IKeyVaultService _keyVaultService;
    private readonly IDbContextProvider _dbContextProvider;


    public TestController(
        IConnectionStringProviderFactory connectionStringProviderFactory, 
        IKeyVaultService keyVaultService,
        IDbContextProvider dbContextProvider
        )
    {
        _connectionStringProviderFactory = connectionStringProviderFactory;
        _keyVaultService = keyVaultService;
        _dbContextProvider = dbContextProvider;
    }

    [HttpGet("string")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ConnectionString()
    {
        var connectionProvider = _connectionStringProviderFactory.GetConnectionStringProvider();
        var connectionString = await connectionProvider.GetConnectionString();

        return Ok(connectionString);
    }

    [HttpGet("context")]
    public async Task<ActionResult> DbContextTest()
    {
        await using var dbContext = await _dbContextProvider.GetDbContext();
        var contextConnectionString = dbContext.Database.GetConnectionString(); 
        return Ok(contextConnectionString);
    }

    [HttpGet("users")]
    public async Task<ActionResult> GetUsers()
    {
        await using var dbContext = await _dbContextProvider.GetDbContext();
        var users = await dbContext.Users.ToListAsync();
        return Ok(users);
    }
    
    [HttpPost("users")]
    public async Task<ActionResult> InsertUser([FromQuery] string username)
    {
        await using var dbContext = await _dbContextProvider.GetDbContext();
        var user = new User
        {
            DisplayName = username,
            Email = $"{username.Replace(" ","")}@contoso.com",
            PasswordHash = "asdf123"
        };

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("keyvault/secret")]
    public async Task<ActionResult> GetKeyVaultSecret([FromQuery] string secretName)
    {
        var secretValue = await _keyVaultService.GetSecretValue(secretName);
        return Ok(secretValue);
    }
    
}