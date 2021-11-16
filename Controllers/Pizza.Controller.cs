using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizza.Mappers;
using pizza.Models;
using pizza.Services;

namespace pizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly IPizzaService _pizzaService;

        public PizzaController(ILogger<PizzaController> logger, IPizzaService pizzaService)
        {
            _logger= logger;
            _pizzaService = pizzaService;
        }
        
        [HttpPost]
        [ActionName(nameof(CreatedAsync))]
        public async Task<IActionResult> CreatedAsync([FromBody]PizzaRequest newPizza)
        {
            var topizzaEntity = newPizza.ToPizzaEntity();
            var insertResult = await _pizzaService.CreatePizzaAsync(topizzaEntity);
          
            if(insertResult.IsSuccess)
            {
                 _logger.LogInformation($"Pizza create in DB: {topizzaEntity.Id}");
                return CreatedAtAction(nameof(CreatedAsync), new {id = topizzaEntity.Id }, topizzaEntity);
            }
          
            return StatusCode((int)HttpStatusCode.InternalServerError);
          
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery]PizzaQuery pizza)
        {
            var pizzas = await _pizzaService.QueryPizzasAsync(title: pizza.Title, id: pizza.Id);

            if(pizzas.Any())
            {
                return Ok(pizzas);
            }

            return NotFound("No pizza exist!");
        }

         [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute]Guid Id)
        {
            var pizza = await _pizzaService.QueryPizzaAsync(Id);
               

            if(pizza is default(Entities.Pizza))
            {
                return NotFound($"User with ID {Id} not found");
            }

            return Ok(pizza);
        }

        [HttpPut]
       [Route("{id}")]
       public async Task<ActionResult> UpdateAsync([FromRoute]Guid id, [FromBody]UpdatedPizza pizza) 
       {
             var topizzaEntity = pizza.ToPizzaEntity();
            var insertResult = await _pizzaService.CreatePizzaAsync(topizzaEntity);
            

             if(!_updatedPizzaValid(pizza))
            {
                return BadRequest("You should change at least one property.");
            }
                return Ok(insertResult.Pizza);
       }

         private bool _updatedPizzaValid(UpdatedPizza updatedPizza)
        {
            return !(updatedPizza.Title == null &&
                    updatedPizza.Ingredients == null &&
                    updatedPizza.ShortName == null &&
                    updatedPizza.Status == null);
        }

         [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {

            var pizzing =  await _pizzaService.RemovePizzaAsync(Id);
              
                return Ok();
            
        }
       
    }
}