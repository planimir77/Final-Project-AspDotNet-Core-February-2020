namespace CustomERP.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class CompaniesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Companies.AnyAsync())
            {
                return;
            }

            var companies = new List<string> { "Vadias", "MKD-69", "UniTrade" };
            foreach (var company in companies)
            {
                await dbContext.Companies.AddAsync(new Company
                {
                    Name = company,
                });
            }
        }
    }
}
