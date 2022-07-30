using Application.Data.Repository;
using Application.Entity.DataManager;
using Application.IService.DataManager;
using Application.Util.Extention;

namespace Application.Service.DataManager
{
    public class CorsService : RepositoryFactory<CorsEntity>, CorsIService
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>MenuEntity</returns>
        public CorsEntity GetEntity(Guid? id)
        {
            return BaseRepository().FindEntity(id);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="paramsJson">查询参数</param>
        /// <returns>MenuEntity</returns>
        public CorsEntity GetEntity(string paramsJson)
        {
         var expression = LinqExtensions.True<CorsEntity>();
            expression = expression.And(s => s.Id == Guid.NewGuid());
            return this.BaseRepository().IQueryable(expression).FirstOrDefault();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="paramsJson"></param>
        /// <returns>IEnumerable<MenuEntity></returns>
        public IEnumerable<CorsEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<CorsEntity>();
            expression = expression.And(s => s.Id == Guid.NewGuid());
            return this.BaseRepository().IQueryable(expression);
        }
        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns>IEnumerable<MenuEntity> </returns>
        public IEnumerable<CorsEntity> GetList()
        {
            var data = this.BaseRepository().FindList();
            return data;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        public void Modify(CorsEntity entity)
        {
            entity.Modify();
            BaseRepository().Update(entity);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entities">List<MenuEntity></param>
        public void Modify(List<CorsEntity> entities)
        {
            foreach (var entity in entities)
                entity.Modify();
            BaseRepository().Update(entities);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        public void SaveForm(CorsEntity entity)
        {
            entity.Create();
            BaseRepository().Insert(entity);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">List<MenuEntity></param>

        public void SaveForm(List<CorsEntity> entities)
        {
            foreach (var entity in entities)
                entity.Create();
            BaseRepository().Insert(entities);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(Guid? id)
        {
            BaseRepository().Delete(id);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="paramsJson">查询参数</param>
        public void Delete(string paramsJson)
        {
            var expression = LinqExtensions.True<CorsEntity>();
            expression = expression.And(s => s.Id == Guid.NewGuid());
            BaseRepository().Delete(expression);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">id</param>
        public void Remove(Guid? id)
        {
            var entity = GetEntity(id);
            entity.Remove();
            BaseRepository().Update(entity);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">MenuEntity</param>
        public void Remove(CorsEntity entity)
        {
            entity.Remove();
            BaseRepository().Update(entity);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities">List<MenuEntity></param>
        public void Remove(List<CorsEntity> entities)
        {
            foreach (var entity in entities)
                entity.Remove();
            BaseRepository().Update(entities);
        }

    }
}

