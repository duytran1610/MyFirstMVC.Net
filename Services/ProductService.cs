using MyFirstApp.Models;

namespace MyFirstApp.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel() {Id = 1, Name = "A1", Price = 1000},
                new ProductModel() {Id = 2, Name = "B2", Price = 1000},
                new ProductModel() {Id = 3, Name = "C3", Price = 1000},
                new ProductModel() {Id = 4, Name = "D4", Price = 1000},
                new ProductModel() {Id = 5, Name = "E5", Price = 1000},
                new ProductModel() {Id = 6, Name = "F6", Price = 1000}
            });
        }
    }
}