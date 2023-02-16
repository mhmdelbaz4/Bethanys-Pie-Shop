using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Display(Name ="First Name")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [StringLength(250)]
        [Required]
        public string Address1 { get; set; }

        [StringLength(250)]
        [Required]
        public string Address2 { get; set; }

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [StringLength(50)]
        [Required]
        public string State { get; set; }

        [StringLength(50)]
        [Required]
        public string Country { get; set; }

        [Display(Name ="Phone Number")]
        [StringLength(50)]
        [Required,DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindNever]
        [DataType(DataType.DateTime)]
        public DateTime DateTimePlaced { get; set; }


        [BindNever]
        public decimal Total { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
