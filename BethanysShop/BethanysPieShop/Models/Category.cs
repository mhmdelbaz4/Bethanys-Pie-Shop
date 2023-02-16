using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public List<Pie> Pies { get; set; }

    }
}
