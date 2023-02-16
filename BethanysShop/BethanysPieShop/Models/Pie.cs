using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BethanysPieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string ShortDescription { get; set; }

        [StringLength(3000)]
        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        [StringLength(200)]
        public string ImageThumbnailUrl { get; set; }

        public bool IsPieOfTheWeek { get; set; }

        public bool InStock { get; set; }

        [StringLength(100)]
        public string AllergyInformation { get; set; }

  
        public int CategoryId { get; set; }

        public Category  Category{ get; set; }
    
       
    }
}
