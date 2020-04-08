using System.Linq;

namespace CustomERP.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class SectionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Sections.AnyAsync())
            {
                return;
            }

            var sections = new List<string> { "Section1", "Section2", "Section3" };

            foreach (var section in sections)
            {
                await dbContext.Sections.AddAsync(new Section
                {
                    Name = section,
                    CreatedFrom = "System",
                    Department = dbContext.Departments.FirstOrDefault(department => department.Name == "Production"),
                });
            }
        }
    }
}
