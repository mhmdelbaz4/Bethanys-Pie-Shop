using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class PieIndexViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }

        public string CurrentCategory { get; set; }

    }
}
