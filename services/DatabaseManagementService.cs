using aspDocker.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspDocker.services
{
    public static class DatabaseManagementService
    {
        /// <summary>
        /// Apply the latest migrations to the specified context
        /// </summary>
        /// <param name="app"></param>
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<NoteContext>().Database.Migrate();
            }
        }
    }
}
