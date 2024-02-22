using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DreamCushion.Models;


    public class PillowMaterialViewModel
    {
    public List<Pillow>? Pillows { get; set; }
    public SelectList? Material { get; set; }
    public string? PillowMaterial { get; set; }
    public string? SearchString { get; set; }
}