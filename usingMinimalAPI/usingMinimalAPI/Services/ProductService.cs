using usingMinimalAPI.Services.DataTransferObjects.Requests;
using usingMinimalAPI.Services.DataTransferObjects.Responses;

namespace usingMinimalAPI.Services
{
    public class ProductService : IProductService
    {
        private List<GetProductInfosResponse> _responses = new List<GetProductInfosResponse>()
        {
            new(1, "Product X", 250),
            new(2, "Product Y", 250),
            new(3, "Product Z", 250),

        };

        public IEnumerable<GetProductInfosResponse> GetProducts()
        {
            return _responses;
        }

        public IEnumerable<GetProductInfosResponse> Search(string name)
        {
            return _responses.Where(p => p.Name.Contains(name));
        }

        public GetProductInfosResponse GetProductById(int id)
        {
            return _responses.SingleOrDefault(p => p.Id == id);
        }

        public int Create(CreateProductRequest request)
        {
            var lastId = _responses.Last().Id + 1;
            GetProductInfosResponse dto = new GetProductInfosResponse(lastId, request.Name, request.Price);
            _responses.Add(dto);
            return lastId;
        }

    }
}
