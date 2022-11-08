using Lima.Businuess;

namespace Lima.UseCases.Interfaces
{
    public interface IViewProducts
    {
        Task<List<Product>> ExecuteAsync(string name = "");
    }
}