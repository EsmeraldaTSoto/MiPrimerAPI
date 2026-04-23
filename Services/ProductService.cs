using MiPrimerAPI.Repositories;

namespace MiPrimerAPI.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task AddProduct(Product product)
        {
            // Ejemplo de lógica (puedes modificar esto)
            if (product.Price <= 0)
            {
                throw new Exception("El precio debe ser mayor que 0");
            }

            await _repository.Add(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _repository.Update(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.Delete(id);
        }
    }
}
