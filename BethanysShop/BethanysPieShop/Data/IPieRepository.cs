using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public interface IPieRepository
    {
        Pie PieById(int id);

        IEnumerable<Pie> PiesByCategory(string category);

        IEnumerable<Pie> GetAllPies();

        IEnumerable<Pie> GetPiesOfTheWeek();

    }
}
