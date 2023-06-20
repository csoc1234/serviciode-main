using APITemplate.Common;
using APITemplate.Domain.Entity;
using APITemplate.Domain.Interface;
using APITemplate.Infraestructure.Interface;

namespace APITemplate.Domain.Core
{
    public class CreateDomain : ICreateDomain
    {
        private readonly ITemplateDbContext _templateDbContext;
        private readonly IConfiguration _configuration;

        public CreateDomain(ITemplateDbContext templateDbContext, IConfiguration configuration)
        {
            _templateDbContext = templateDbContext;
            _configuration = configuration;
        }

        public async Task<ResponseBase> Create(Template template)
        {
            try
            {

                int result = _templateDbContext.SaveTemplate(
                    template.ProductId,
                    template.CustomerId,
                    template.NameTemplate,
                    template.Source,
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    true,
                    _configuration
                    );

                if (result > 0)
                {
                    return new ResponseBase
                    {
                        Code = 200,
                        Message = "Se registro con exito"
                    };
                }
                else
                {
                    return new ResponseBase
                    {
                        Code = 422,
                        Message = "No se logro registrar el template"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase
                {
                    Code = 500,
                    Message = "Error al momento de registrar el template"
                };
            }
        }
    }
}