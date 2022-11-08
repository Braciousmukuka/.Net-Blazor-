namespace Lima.UseCases.Interfaces
{
    public interface IDeleteProduct
    {
        Task ExecuteAsync(int productId);
    }
}