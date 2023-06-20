namespace APITemplate.Infraestructure.Interface
{
    public interface ITemplateDbContext
    {
        int SaveTemplate(Int16 productId, int customerId, string nameTemplate, Byte[] source, DateTime dateFrom, DateTime dateTo, Boolean active, IConfiguration configuration);
    }
}
