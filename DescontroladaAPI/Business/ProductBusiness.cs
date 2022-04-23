using DescontroladaAPI.Interfaces;
using DescontroladaAPI.Models;

namespace DescontroladaAPI.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepository _repository;

        public ProductBusiness(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<ProductModel> GetProducts(
            int id,
            string? name,
            string? description,
            double? sellPrice,
            int? quantity,
            bool? isOrganic,
            DateTime? RegisterDate)
        {
            isOrganic = id > 0 ? null : isOrganic;
            return _repository.GetProducts(id, name, description, sellPrice, quantity, isOrganic, RegisterDate);
        }

        public void InsertProduct(ProductModel product)
        {
            product.Id = null;

            _repository.InsertProduct(product);
        }

        public void UpdateProduct(ProductModel product)
        {
            _repository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Please inform the ID of the product to be deleted");
            }

            _repository.DeleteProduct(id);
        }
    }
}
