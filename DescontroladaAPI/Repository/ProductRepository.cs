using DescontroladaAPI.Interfaces;
using DescontroladaAPI.Models;
using System.Data.Entity;

namespace DescontroladaAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiContext _context;

        public ProductRepository(ApiContext context)
        {
            _context = context;
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
            return _context.Products
                .Where(x => id == 0 || x.Id == id)
                .Where(x => isOrganic == null || x.IsOrganic == isOrganic)
                .Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name))
                .Where(x => string.IsNullOrEmpty(description) || x.Description.Contains(description))
                .Where(x => sellPrice == null || x.SellPrice == sellPrice)
                .Where(x => quantity == null || x.Quantity == quantity)
                .Where(x => RegisterDate == null || x.RegisterDate.Date == RegisterDate.Value.Date)
            .ToList();
                
        }

        public void InsertProduct(ProductModel product)
        {
            Execute((ApiContext _context) => _context.Products.Add(product));
        }

        public void UpdateProduct(ProductModel product)
        {
            ProductModel? dbProduct = _context.Products.SingleOrDefault(x => x.Id == product.Id);

            if (dbProduct == null)
            {
                throw new Exception($"Employee with the Id {product.Id} does not exist.");
            }

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.SellPrice = product.SellPrice;
            dbProduct.Quantity = product.Quantity;
            dbProduct.RegisterDate = product.RegisterDate;
            dbProduct.IsOrganic = product.IsOrganic;

            Execute((ApiContext _context) => _context.Update(product));
        }

        public void DeleteProduct(int id)
        {
            ProductModel? product = _context.Products.SingleOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new Exception($"Employee with the Id {id} does not exist.");
            }

            Execute((ApiContext _context) => _context.Remove(product));
        }

        protected void Execute(Action<ApiContext> action)
        {
            try
            {
                action.Invoke(_context);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
