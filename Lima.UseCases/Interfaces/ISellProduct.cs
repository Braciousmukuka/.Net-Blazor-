using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface ISellProduct
    {
        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
    }
}