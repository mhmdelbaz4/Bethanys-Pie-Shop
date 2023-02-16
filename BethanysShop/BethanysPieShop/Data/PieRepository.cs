using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Data
{
    public class PieRepository : IPieRepository
    {
        private readonly ApplicationDbContext context;

        public PieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return context.Pies.ToList();
        }

        public IEnumerable<Pie> GetPiesOfTheWeek()
        {
            var piesOfTheWeek = context.Pies.Where(p => p.IsPieOfTheWeek).ToList();

            return piesOfTheWeek;
        }

        public Pie PieById(int id)
        {
            return context.Pies.Find(id);
        }

        public IEnumerable<Pie> PiesByCategory(string category)
        {
            var pies = context.Pies.Where(p => p.Category.CategoryName == category)
                                    .Include(p => p.Category).ToList();


            return pies;
        }
    }
}
