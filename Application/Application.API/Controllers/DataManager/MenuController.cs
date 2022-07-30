using Application.Busines.DataManager;
using Application.Entity.DataManager;
using Application.Util.Operator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private MenuBLL menuBLL = new MenuBLL();
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MenuEntity</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult< MenuEntity> GetEntity(Guid? id)
        {
            var entity = menuBLL.GetEntity(id);
            return Success("操作成功", entity);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="paramsJson">查询参数</param>
        /// <returns>MenuEntity</returns>
        [HttpGet]
        [Route("{paramsJson}")]
        public ActionResult<MenuEntity> GetEntity(string paramsJson)
        {

            return menuBLL.GetEntity(paramsJson);
        }
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="paramsJson"></param>
        /// <returns>IEnumerable MenuEntity  </returns>
        [HttpGet]
        [Route("{paramsJson}")]
        public ActionResult<IEnumerable<MenuEntity>> GetList(string paramsJson)
        {
            var data = menuBLL.GetList(paramsJson);
            return Success("", data);
        }
        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns>IEnumerable MenuEntity </returns>
        [HttpGet]
        [Authorize]
        public IEnumerable<MenuEntity> GetList()
        {
            Operator user =   OperatorProvider.Provider.Current();
            return menuBLL.GetList();

        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        [HttpPut]
        [Route("{entity}")]
        public void Modify(MenuEntity entity)
        {
            menuBLL.Modify(entity);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entities">List MenuEntity </param>
        [HttpPut]
        [Route("{entities}")]
        public void Modify(List<MenuEntity> entities)
        {
            menuBLL.Modify(entities);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        [HttpPost]
        [Route("{entity}")]
        public void SaveForm(MenuEntity entity)
        {
            menuBLL.SaveForm(entity);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entities">List MenuEntity </param>
        [HttpPost]
        [Route("{entities}")]
        public void SaveForm(List<MenuEntity> entities)
        {
            menuBLL.SaveForm(entities);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">id</param>
        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid? id)
        {
            menuBLL.Delete(id);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="paramsJson">查询参数</param>
        [HttpDelete]
        [Route("{paramsJson}")]
        public void Delete(string paramsJson)
        {
            menuBLL.Delete(paramsJson);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">id</param>
        [HttpDelete]
        [Route("{id}")]
        public void Remove(Guid? id)
        {
            menuBLL.Remove(id);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        [HttpDelete]
        [Route("{entity}")]
        public void Remove(MenuEntity entity)
        {
            menuBLL.Remove(entity);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities">List MenuEntity </param>
        [HttpDelete]
        [Route("{entities}")]
        public void Remove(List<MenuEntity> entities)
        {
            menuBLL.Remove(entities);
        }

    }
}
