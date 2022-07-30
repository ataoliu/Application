
using Application.Entity.DataManager;
using Application.IBusines.DataManager;
using Application.IService.DataManager;
using Application.Service.DataManager;

namespace Application.Busines.DataManager
{
    public class CorsBLL:CorsIBLL
    {
       private readonly CorsIService _service=new CorsService();
        //public CorsBLL(CorsService service)
        //{
        //    _service = service;
        //}

        public IEnumerable<CorsEntity> GetList()
        {
            return _service.GetList().Where(s => s.DeleteMark == false);
        }
    }
}

