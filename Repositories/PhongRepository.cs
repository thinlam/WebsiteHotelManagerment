using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Repositories
{
    public class PhongRepository
    {
        private readonly ApplicationDbContext _context;

        public PhongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Phong> GetAll() => _context.Phongs.ToList();
        public Phong GetById(int id) => _context.Phongs.Find(id);

        public void Add(Phong item)
        {
            _context.Phongs.Add(item);
            _context.SaveChanges();
        }

        public void Update(Phong item)
        {
            _context.Phongs.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Phongs.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
