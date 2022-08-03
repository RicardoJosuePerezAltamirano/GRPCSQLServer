using Grpc.Core;
using GrpcService1;
namespace GrpcService1.Services
{
    public class ProductsService:Products.ProductsBase
    {
        public ProductsService()
        {

        }

        public override Task<ProductsDTO> GetProducts(ProductsRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ProductsDTO()
            {
                Productid = request.Price+600
            }); ;
        }



    }
}
