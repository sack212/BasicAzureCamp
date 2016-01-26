using System.Web.Http.Description;
using Swashbuckle.Swagger;
using System.Web.Http;

namespace Swashbuckle.SwaggerExtensions
{
    public class AddDefaultResponse : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (!operation.responses.ContainsKey("default") && operation.responses.ContainsKey("200"))
            {
                operation.responses.Add("default", operation.responses["200"]);
            }
        }
    }
}