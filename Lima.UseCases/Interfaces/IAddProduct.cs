using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IAddProduct
    {
        Task ExecuteAsync(Product product);
    }
}