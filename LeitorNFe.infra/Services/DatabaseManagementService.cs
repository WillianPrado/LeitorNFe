using System;
using System.Collections.Generic;
using System.Text;
using LeitorNFe.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LeitorNFe.Infra.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                 .GetService<LeitorNFeContext>();

                serviceDb.Database.Migrate();
            }
        }
    }
}