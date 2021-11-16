using pizza.Entities;

namespace pizza.Mappers
{
    public static class PizzaModelEntityMapper
{
    public static Entities.Pizza ToPizzaEntity(this Models.PizzaRequest pizza)
    {
        return new Pizza(
                title: pizza.Title,
                ingredients: string.Join(',', pizza.Ingredients),
                shortname : pizza.ShortName,
                price : pizza.Price,
                status : pizza.Status.ToEntitiesEPizzaStatus()
        );
    }

    public static Entities.Pizza ToPizzaEntity(this Models.UpdatedPizza newpizza)
    {
        return new Pizza(
                title: newpizza.Title,
                ingredients: string.Join(',', newpizza.Ingredients),
                shortname : newpizza.ShortName,
                price : newpizza.Price,
                status : newpizza.Status.ToEntitiesEPizzaStatus()
        );
    }
}
}