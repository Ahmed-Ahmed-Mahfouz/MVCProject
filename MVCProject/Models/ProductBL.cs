namespace MVCProject.Models
{
    public class ProductBL
    {
        List<Product> products;
        public ProductBL()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Product 1", Price = 100, ImageURL = "product1.jpeg" });
            products.Add(new Product() { Id = 2, Name = "Product 2", Price = 200, ImageURL = "product2.jpeg" });
            products.Add(new Product() { Id = 3, Name = "Product 3", Price = 300, ImageURL = "product3.jpeg" });
        }
        public Product GetByID(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
        public List<Product> GetAll()
        {
            return products;
        }
    }
}
