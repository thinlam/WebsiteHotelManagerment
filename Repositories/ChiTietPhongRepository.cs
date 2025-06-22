using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Repositories
{
    public class ChiTietPhongRepository
    {
        private readonly ApplicationDbContext _context;

        public ChiTietPhongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ChiTietPhong> GetAll() => _context.ChiTietPhongs.ToList();

        public ChiTietPhong GetById(int id) => _context.ChiTietPhongs.Find(id);

        public void Add(ChiTietPhong item)
        {
            _context.ChiTietPhongs.Add(item);
            _context.SaveChanges();
        }

        public void Update(ChiTietPhong item)
        {
            _context.ChiTietPhongs.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.ChiTietPhongs.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
