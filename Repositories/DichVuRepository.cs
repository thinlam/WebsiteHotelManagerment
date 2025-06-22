using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Repositories
{
    public class DichVuRepository
    {
        private readonly ApplicationDbContext _context;

        public DichVuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DichVu> GetAll() => _context.DichVus.ToList();
        public DichVu GetById(int id) => _context.DichVus.Find(id);

        public void Add(DichVu item)
        {
            _context.DichVus.Add(item);
            _context.SaveChanges();
        }

        public void Update(DichVu item)
        {
            _context.DichVus.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.DichVus.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
