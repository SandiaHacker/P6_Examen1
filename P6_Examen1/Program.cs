using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P6_Examen1.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //PASO 1
        var CnnStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CnnStr"));


        //PASO2
        CnnStrBuilder.Password = "123Queso";


        //PASO3
        string cnnStr = CnnStrBuilder.ConnectionString;


        //PASO4
        builder.Services.AddDbContext<Ex1p6assets20243Context>(Options => Options.UseSqlServer(cnnStr));


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}