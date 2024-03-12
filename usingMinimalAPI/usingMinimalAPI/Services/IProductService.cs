using usingMinimalAPI.Services.DataTransferObjects.Requests;
using usingMinimalAPI.Services.DataTransferObjects.Responses;

namespace usingMinimalAPI.Services
{
    public interface IProductService
    {
        int Create(CreateProductRequest request);
        GetProductInfosResponse GetProductById(int id);
        IEnumerable<GetProductInfosResponse> GetProducts();
        IEnumerable<GetProductInfosResponse> Search(string name);
    }
}