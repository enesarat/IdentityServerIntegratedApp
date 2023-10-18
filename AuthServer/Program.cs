var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(AuthServer.Config.GetApiResources())
    .AddInMemoryApiScopes(AuthServer.Config.GetApiScopes())
    .AddInMemoryClients(AuthServer.Config.GetClients())
    .AddDeveloperSigningCredential();

builder.Services.AddControllers();
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
// We call our IdentityServer Middleware before Authorization Middleware.
app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.Run();
