using mangas.Services.Features.Mangas;
using mangas.Infrastructure. Repositories;
using manga.Serivices.MappingsM;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container. 

builder.Services.AddScoped<MangaService>();
builder.Services.AddScoped<MangaService>();
builder.Services.AddTransient<MangaRepository>();

builder. Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at http
builder. Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app. Environment. IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();