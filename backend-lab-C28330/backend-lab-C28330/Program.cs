var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregar servicio CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", policy =>
    {
        policy.WithOrigins("http://localhost:8080");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Usar CORS
app.UseCors("NuevaPolitica");

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
