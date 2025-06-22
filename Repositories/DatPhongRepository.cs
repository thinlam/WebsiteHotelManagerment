using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Repositories
{
    public class DatPhongRepository
    {
        private readonly ApplicationDbContext _context;

        public DatPhongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DatPhong> GetAll() => _context.DatPhongs.ToList();
        public DatPhong GetById(int id) => _context.DatPhongs.Find(id);

        public void Add(DatPhong item)
        {
            _context.DatPhongs.Add(item);
            _context.SaveChanges();
        }

        public void Update(DatPhong item)
        {
            _context.DatPhongs.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.DatPhongs.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
