using System;
using ConsoleAppEFTransaction;
using ConsoleAppEFTransaction.Modele;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<CompanyContext>(options =>
                    options.UseSqlServer(connectionString));
            })
            .Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<CompanyContext>();

            var optionsBuilder = new DbContextOptionsBuilder<CompanyContext>();
            optionsBuilder.UseSqlServer(context.Database.GetDbConnection().ConnectionString);

            using (var transactionContext = new CompanyContext(optionsBuilder.Options))
            {
                using (var transaction = transactionContext.Database.BeginTransaction())
                {
                    try
                    {
                        var employe = new Employe { Name = "John Doe" };
                        transactionContext.Employes.Add(employe);
                        transactionContext.SaveChanges();

                        var userTask = new UserTask { Description = "Complete project", EmployeId = employe.EmployeId };
                        transactionContext.UserTasks.Add(userTask);
                        transactionContext.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
