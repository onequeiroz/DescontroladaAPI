using DescontroladaAPI.Models;

namespace DescontroladaAPI.Interfaces
{
    public interface IProductBusiness
    {
        List<ProductModel> GetProducts(
            int id,
            string? name,
            string? description,
            double? sellPrice,
            int? quantity,
            bool? isOrganic,
            DateTime? RegisterDate);

        void InsertProduct(ProductModel product);

        void UpdateProduct(ProductModel product);

        void DeleteProduct(int id);
    }
}
