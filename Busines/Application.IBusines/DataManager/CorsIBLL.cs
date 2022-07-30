
using Application.Entity.DataManager;

namespace Application.IBusines.DataManager
{
    public interface CorsIBLL
    {
        public IEnumerable<CorsEntity> GetList();
    }
}

