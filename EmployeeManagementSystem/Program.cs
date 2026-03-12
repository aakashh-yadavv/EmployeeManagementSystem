using EmployeeManagementSystem.DATA;
using EmployeeManagementSystem.Mapper;
using EmployeeManagementSystem.Repository.Implement;
using EmployeeManagementSystem.Repository.Interface;
using EmployeeManagementSystem.Repository.ServiceClass;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<EmployeeDbContext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("EmpDb"));

        });
        builder.Services.AddScoped<IDepartment, DepServiceClass>();
        builder.Services.AddScoped<IEmployees, EmpService>();
        builder.Services.AddScoped<IAddress, AddressService>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var app = builder.Build();

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
    }
}