using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Repositories
{
    public class ThanhToanRepository
    {
        private readonly ApplicationDbContext _context;

        public ThanhToanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ThanhToan> GetAll() => _context.ThanhToans.ToList();
        public ThanhToan GetById(int id) => _context.ThanhToans.Find(id);

        public void Add(ThanhToan item)
        {
            _context.ThanhToans.Add(item);
            _context.SaveChanges();
        }

        public void Update(ThanhToan item)
        {
            _context.ThanhToans.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.ThanhToans.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
