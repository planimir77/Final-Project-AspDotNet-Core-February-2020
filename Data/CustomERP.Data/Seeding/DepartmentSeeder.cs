namespace CustomERP.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Departments.AnyAsync())
            {
                return;
            }

            await dbContext.Departments.AddAsync(new Department() { Name = "Production" });
            await dbContext.Departments.AddAsync(new Department() { Name = "Administration" });
        }
    }
}
