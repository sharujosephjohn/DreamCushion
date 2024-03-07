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
                    },
                    new Pillow
                    {
                        Name = "CozyRest Memory Foam Pillow",
                        Material = "Memory Foam",
                        Size = "Standard",
                        Price = 34.99M,
                        Rating = 4.7M
                    },
    new Pillow
    {
        Name = "SoftTouch Microfiber Pillow",
        Material = "Microfiber",
        Size = "Standard",
        Price = 19.99M,
        Rating = 4.3M
    },
    new Pillow
    {
        Name = "EcoBliss Bamboo Pillow",
        Material = "Bamboo",
        Size = "King",
        Price = 49.99M,
        Rating = 4.9M
    },
    new Pillow
    {
        Name = "DreamFoam Gel Pillow",
        Material = "Gel",
        Size = "Queen",
        Price = 29.99M,
        Rating = 4.6M
    },
    new Pillow
    {
        Name = "CloudComfort Cooling Pillow",
        Material = "Gel-infused Memory Foam",
        Size = "Standard",
        Price = 49.99M,
        Rating = 4.6M
    },
    new Pillow
        {
        Name = "AirFlow Breathable Pillow",
        Material = "Polyester",
        Size = "Standard",
        Price = 24.99M,
        Rating = 4.2M
    },
    new Pillow
    {
        Name = "SilkDreams Luxury Pillow",
        Material = "Silk",
        Size = "Queen",
        Price = 59.99M,
        Rating = 4.9M
    },
    new Pillow
    {
        Name = "OrthoSupport Orthopedic Pillow",
        Material = "Memory Foam",
        Size = "Queen",
        Price = 39.99M,
        Rating = 4.7M
    }

            );
            context.SaveChanges();
        }
    }
}