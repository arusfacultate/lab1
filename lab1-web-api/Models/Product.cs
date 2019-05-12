using System.ComponentModel.DataAnnotations;

namespace lab1_web_api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Range(1, 700)]
        public double Price { get; set; }
    }
}
