using System;
using Application.Entity.DataManager;

namespace Application.IService.DataManager
{
	/// <summary>
	/// MenuIservicessss
	/// </summary>
	public interface MenuIService
	{
		public MenuEntity GetEntity(Guid? id);
		public MenuEntity GetEntity(string paramsJson);
		public IEnumerable<MenuEntity> GetList(string paramsJson);
		public IEnumerable<MenuEntity> GetList();

		public void SaveForm(MenuEntity entity);
		public void SaveForm(List< MenuEntity> entities);

		public void Delete(Guid? id);
		public void Delete(string paramsJson);

		public void Modify(MenuEntity entity);
		public void Modify(List<MenuEntity> entities);

		public void Remove(Guid? id);
		public void Remove(MenuEntity entity);
		public void Remove(List<MenuEntity> entities);
    }
}

