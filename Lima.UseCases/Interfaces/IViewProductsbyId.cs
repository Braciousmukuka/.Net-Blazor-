using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IViewProductsbyId
    {
        Task<Product> ExecuteAsync(int productId);
    }
}