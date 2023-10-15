using PlatformService.Data;
using PlatformService.Models;
using PlatformService.Repositories.Interfaces;

namespace PlatformService.Repositories
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlateform(Platform platform)
        {
            if(platform == null) { 
             throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);  
            SaveChanges();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public Platform GetPlatformByName(string name)
        {
          return  _context.Platforms.FirstOrDefault(p => p.Name == name);
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
