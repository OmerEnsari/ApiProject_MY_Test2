using ApiProject.WebAPI.Entities;

namespace ApiProject.WebAPI.Dtos.ProductDtos
{
    public class ResultProductWithCategory
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
