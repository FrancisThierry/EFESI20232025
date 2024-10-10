using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFTransaction.Modele
{
    public class CompanyContext:DbContext
    {
        public DbSet<Employe> Employes { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

    }
}
