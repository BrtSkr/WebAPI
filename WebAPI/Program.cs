var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHttpMethodOverride();
app.UseCors(options =>
{
    //options.WithOrigins(MyAllowSpecificOrigins).AllowAnyHeader().AllowAnyMethod();
    options.AllowAnyOrigin();
});
//app.UseAuthorization();

app.MapControllers();

app.Run();
