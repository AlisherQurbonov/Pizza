using System;
using Microsoft.AspNetCore.Mvc;

namespace pizza.Models
{
    public class PizzaQuery
    {
        [FromQuery]
        public string Title { get; set; }

        [FromQuery]
        public Guid Id { get; set; }

      
         [FromQuery]
         public string Status { get; set; }
         
    }
}