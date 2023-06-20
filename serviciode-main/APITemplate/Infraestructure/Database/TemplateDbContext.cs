using APITemplate.Domain.Entity;
using APITemplate.Infraestructure.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APITemplate.Infraestructure.Database
{
    public class TemplateDbContext : DbContext, ITemplateDbContext
    {
        private readonly IConfiguration _configuration;
        public TemplateDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Template> Templates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
            }
        }

        public int SaveTemplate(Int16 productId, int customerId, string nameTemplate, Byte[] source, DateTime dateFrom, DateTime dateTo, Boolean active, IConfiguration configuration)
        {
            try
            {
                SqlParameter productIdParam = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Input,
                    ParameterName = "@product_id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productId
                };

                SqlParameter customerIdParam = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Input,
                    ParameterName = "@customer_id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = customerId
                };

                SqlParameter nameTemplateParam = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Input,
                    ParameterName = "@name_template",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = nameTemplate
                };

                SqlParameter sourceParam = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Input,
                    ParameterName = "@source",
                    SqlDbType = System.Data.SqlDbType.VarBinary,
                    Value = source
                };

                SqlParameter dateFromParam = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Input,
                    ParameterName = "@date_from",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = dateFrom
                };

                SqlParameter dateToParam = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Input,
                    ParameterName = "@date_to",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = dateTo
                };

                SqlParameter activeParam = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Input,
                    ParameterName = "@active",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = active
                };

                SqlParameter[] parameters = new SqlParameter[]
                {
                    productIdParam, customerIdParam, nameTemplateParam, sourceParam, dateFromParam, dateToParam, activeParam
                };

                using (TemplateDbContext? db_template = new TemplateDbContext(configuration))
                {
                    int result = db_template.Database.ExecuteSqlRaw("EXEC db_template.uspTemplateCreate " +
                           "@product_id, " + "@customer_id, " + "@name_template, " + "@source, " + "@date_from, " + "@date_to, " + "@active", parameters);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
