using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IProduceProduct
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}