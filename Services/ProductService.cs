using AppMvc.Net.Models;

namespace AppMvc.Net.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id = 1, Name = "Iphone X", Price = 1000},
                new ProductModel() {Id = 2, Name = "Iphone XY", Price = 500},
                new ProductModel() {Id = 3, Name = "Iphone XYZ", Price = 900},
                new ProductModel() {Id = 4, Name = "Iphone XYZT", Price = 1000},
            });
        }
    }
}