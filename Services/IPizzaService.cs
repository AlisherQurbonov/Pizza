using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pizza.Entities;

namespace pizza.Services
{
    public interface IPizzaService
    {
        Task<List<Entities.Pizza>> QueryPizzasAsync(Guid id = default(Guid),
            string title = default(string),
            string shortname = default(string),
            Entities.EStockStatus? status = null,
            string indergenties = default(string),
            double price = default(double));
        Task<Pizza> QueryPizzaAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> CreatePizzaAsync(Pizza pizza);
        Task<bool> PizzaExistsAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> UpdatePizzaAsync(Pizza pizza);
        Task<(bool IsSuccess, Exception Exception)> RemovePizzaAsync(Guid id);
    }
}