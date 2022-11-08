using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IValidateEnoughInventories4Production
    {
        Task<bool> ExecuteAsync(Product product, int quantity);
    }
}