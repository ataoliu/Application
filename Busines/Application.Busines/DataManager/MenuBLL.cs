using System;
using Application.Entity.DataManager;
using Application.IService.DataManager;
using Application.Service.DataManager;

namespace Application.Busines.DataManager
{
	public class MenuBLL
	{

		private MenuIService menuIService = new MenuService();
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>MenuEntity</returns>
        public MenuEntity GetEntity(Guid? id)
        {
            return menuIService.GetEntity(id);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="paramsJson">查询参数</param>
        /// <returns>MenuEntity</returns>
        public MenuEntity GetEntity(string paramsJson)
        {
           
            return menuIService.GetEntity(paramsJson);
        }
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="paramsJson"></param>
        /// <returns>IEnumerable<MenuEntity></returns>
        public IEnumerable<MenuEntity> GetList(string paramsJson)
        {
          return  menuIService.GetList(paramsJson);
        }
        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns>IEnumerable<MenuEntity> </returns>
        public IEnumerable<MenuEntity> GetList()
        {
            return menuIService.GetList();

        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        public void Modify(MenuEntity entity)
        {
            menuIService.Modify(entity);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entities">List<MenuEntity></param>
        public void Modify(List<MenuEntity> entities)
        {
            menuIService.Modify(entities);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        public void SaveForm(MenuEntity entity)
        {
            menuIService.SaveForm(entity);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">List<MenuEntity></param>

        public void SaveForm(List<MenuEntity> entities)
        {
            menuIService.SaveForm(entities);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(Guid? id)
        {
            menuIService.Delete(id);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="paramsJson">查询参数</param>
        public void Delete(string paramsJson)
        {
            menuIService.Delete(paramsJson);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">id</param>
        public void Remove(Guid? id)
        {
            menuIService.Remove(id);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        public void Remove(MenuEntity entity)
        {
            menuIService.Remove(entity);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities">List<MenuEntity></param>
        public void Remove(List<MenuEntity> entities)
        {
            menuIService.Remove(entities);
        }
    }
}

