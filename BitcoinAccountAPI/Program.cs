using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    // The address of the Auth Server that issued the token is declared. That is, the address of the mechanism that distributes authorization is declared and associated with the relevant API.
                    options.Authority = "https://localhost:7183";
                    // This API is associated with the resource named 'Bitcoin' in the Auth Server application.
                    options.Audience = "Bitcoin";
                });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ReadBitcoin", policy => policy.RequireClaim("scope", "Bitcoin.Read"));
    options.AddPolicy("WriteBitcoin", policy => policy.RequireClaim("scope", "Bitcoin.Write"));
    options.AddPolicy("AdminBitcoin", policy => policy.RequireClaim("scope", "Bitcoin.Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
