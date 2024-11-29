using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BenefitsCalculator.Service.Interfaces;

namespace BenefitsCalculator.Service
{
    public static class Bootstrapper
    {
        // Register types only for current layer and called registration method for layer below.
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<DependentService>().As<IDependentService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();

            // Initiate registration for layer below this one

            Repository.Bootstrapper.RegisterTypes(builder);
        }
    }
}
