using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenefitsCalculator.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BenefitsCalculator.Repository
{
    public class BenefitsCauclatorEFDbContext : DbContext
    {
        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BenefitsCalculator");
        }
    }
}
