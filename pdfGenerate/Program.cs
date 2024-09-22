using Microsoft.EntityFrameworkCore;
using pdfGenerate.Data;
using pdfGenerate.Service.Implementation;
using pdfGenerate.Service.Interface;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
QuestPDF.Settings.License = LicenseType.Community;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region dbConnection
builder.Services.AddDbContext<ProductDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
});
#endregion
#region dependencyInjection
 builder.Services.AddScoped<IProduct, ProductService>();
 builder.Services.AddScoped<IPDF, PDFService>();
#endregion
#region FrontEndConnection
builder.Services.AddCors(setup =>
{
    setup.AddPolicy("default", option =>
    {
        option.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("default");
app.UseAuthorization();

app.MapControllers();

app.Run();
