using FluentValidation.AspNetCore;
using GADistribuidora.Infraestructure.ProgramConfigurations.Containers;
using GADistribuidora.Infraestructure.ProgramConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add(new ApiExceptionFilterAttribute());
//});

builder.AddDbContext();

builder.Services.AddControllers().AddFluentValidation(config => 
{
    config.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});

builder.AddAuthentication();

builder.AddIdentity();

builder.AddContainers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddCors();

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
app.UseCors("AllowAnyOrigin");

app.MapControllers();

app.Run();
