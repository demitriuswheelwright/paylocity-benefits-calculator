using Autofac;
using Microsoft.EntityFrameworkCore;

namespace BenefitsCalculator.Repository
{
    public static class Bootstrapper
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<BenefitsCauclatorEFDbContext>().As<DbContext>();
        }
    }
}
