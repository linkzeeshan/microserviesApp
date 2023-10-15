using PlatformService.Models;

namespace PlatformService.Repositories.Interfaces
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        Platform GetPlatformByName(string name);
        void CreatePlateform(Platform platform);
    }
}
