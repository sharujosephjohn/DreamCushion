using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DreamCushion.Data;
using System;
using System.Linq;

namespace DreamCushion.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DreamCushionContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DreamCushionContext>>()))
        {
            // Look for any movies.
            if (context.Pillow.Any())
            {
                return;   // DB has been seeded
            }
            context.Pillow.AddRange(
                new Pillow
                {
                    Name = "ComfortCloud Premium Pillow",
                    Material = "Memory Foam",
                    Size = "Standard",
                    Price = 29.99M,
                    Rating = 4.5M
                },
                    new Pillow
                    {
                        Name = "LuxuryDream Plush Pillow",
                        Material = "Down Alternative",
                        Size = "Queen",
                        Price = 39.99M,
                        Rating = 4.8M
                    }
                    
            );
            context.SaveChanges();
        }
    }
}