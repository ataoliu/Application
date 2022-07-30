using System;
using Application.Entity.DataManager;

namespace Application.IService.DataManager
{
    public interface CorsIService
    {
		public CorsEntity GetEntity(Guid? id);
		public CorsEntity GetEntity(string paramsJson);
		public IEnumerable<CorsEntity> GetList(string paramsJson);
		public IEnumerable<CorsEntity> GetList();

		public void SaveForm(CorsEntity entity);
		public void SaveForm(List<CorsEntity> entities);

		public void Delete(Guid? id);
		public void Delete(string paramsJson);

		public void Modify(CorsEntity entity);
		public void Modify(List<CorsEntity> entities);

		public void Remove(Guid? id);
		public void Remove(CorsEntity entity);
		public void Remove(List<CorsEntity> entities);
	}
}

