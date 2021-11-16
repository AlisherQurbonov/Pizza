namespace pizza.Mappers
{
    public static class EnumMapper
    {
      public static Entities.EStockStatus ToEntitiesEPizzaStatus(this Models.EStockStatus? status)
        {
            return status switch
            {
                Models.EStockStatus.OUT => Entities.EStockStatus.OUT,
                  _ => Entities.EStockStatus.IN,
               
            };
        }
    }
}