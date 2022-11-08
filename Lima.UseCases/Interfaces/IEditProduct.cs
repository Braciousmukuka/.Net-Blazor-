using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IEditProduct
    {
        Task ExecuteAsync(Product product);
    }
}