using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pizza.Models
{
    public class UpdatedPizza
    {
    [MaxLength(255)]
    public string Title { get; set; }

    [MaxLength(255)]
    public List<string> Ingredients { get; set; }

    [MaxLength(3)]
    [MinLength(3)]
    public string ShortName { get; set; }

    [Range(1, double.MaxValue)]
    public double Price { get; set; }

    public EStockStatus? Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }


    }
}