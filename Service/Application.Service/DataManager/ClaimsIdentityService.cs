using System;
using Application.Data.Repository;
using Application.Entity.DataManager;
using Application.IService.DataManager;
using Application.Util.Extention;
using Application.Util.Helper;
using Application.Util.Model;

namespace Application.Service.DataManager
{
    public class ClaimsIdentityService : RepositoryFactory<ClaimsIdentityEntity>, ClaimsIdentityIService
    {
        private readonly JwtHelper _jwtHelper;


        public ClaimsIdentityService(JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }
        public TokenMode CreateToken(UserTokenModel model)
        {
            var token = _jwtHelper.CreateToken(model, out Guid refreshToken, out var expirationTime);
            TokenMode tokenMode = new TokenMode();
            tokenMode.AccessToken = token;
            tokenMode.RefreshToken = refreshToken;
            ClaimsIdentityEntity entity = new ClaimsIdentityEntity();
            var entityList = GetList("{\"UserId\":\"" + model.UserId + "\"}");
            //删除之前的token;
            if (entityList.Count() > 0)
            {
                Remove(entityList);
            }

            entity.UserId = model.UserId;
            entity.RefreshToken = refreshToken;
            entity.AccessToken = token;
            entity.ExpirationTime = expirationTime;

            this.SaveForm(entity);
            return tokenMode;
        }
        public bool Expired(Guid? refreshToken)
        {
            string parames = "{\"RefreshToken\":\"" + refreshToken.ToString() + "\"}";
            var entity = GetEntity(parames);
            if (entity == null)
                return true;
            return entity.ExpirationTime < DateTime.Now ? true : false;
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>ClaimsIdentityEntity</returns>
        public ClaimsIdentityEntity GetEntity(Guid? id)
        {
            return BaseRepository().FindEntity(id);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="paramsJson">查询参数</param>
        /// <returns>ClaimsIdentityEntity</returns>
        public ClaimsIdentityEntity GetEntity(string paramsJson)
        {
            var expression = LinqExtensions.True<ClaimsIdentityEntity>();
            expression = expression.And(s => s.DeleteMark == false);
            if (!paramsJson.IsEmpty())
            {
                var parames = paramsJson.ToJObject();
                if (!parames["RefreshToken"].IsEmpty())
                {
                    var RefreshToken = (Guid)parames["RefreshToken"];
                    expression = expression.And(s => s.RefreshToken == RefreshToken);
                }
            }
            return this.BaseRepository().IQueryable(expression).FirstOrDefault();
        }
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="paramsJson"></param>
        /// <returns>IEnumerable ClaimsIdentityEntity</returns>
        public IEnumerable<ClaimsIdentityEntity> GetList(string paramsJson)
        {
            var expression = LinqExtensions.True<ClaimsIdentityEntity>();
            expression = expression.And(s => s.DeleteMark == false);
            if (!paramsJson.IsEmpty())
            {
                var parames = paramsJson.ToJObject();
                if (!parames["UserId"].IsEmpty())
                {
                    var userId = (Guid)parames["UserId"];
                    expression = expression.And(s => s.UserId == userId);
                }
            }
            return this.BaseRepository().IQueryable(expression);
        }
        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns>IEnumerable ClaimsIdentityEntity </returns>
        public IEnumerable<ClaimsIdentityEntity> GetList()
        {
            var data = this.BaseRepository().FindList();
            return data;

        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity">ClaimsIdentityEntity</param>
        public void Modify(ClaimsIdentityEntity entity)
        {
            entity.Modify();
            BaseRepository().Update(entity);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entities">List ClaimsIdentityEntity</param>
        public void Modify(IEnumerable<ClaimsIdentityEntity> entities)
        {
            foreach (var entity in entities)
                entity.Modify();
            BaseRepository().Update(entities.ToList());
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">ClaimsIdentityEntity</param>
        public void SaveForm(ClaimsIdentityEntity entity)
        {
            entity.Create();
            BaseRepository().Insert(entity);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">List ClaimsIdentityEntity</param>

        public void SaveForm(IEnumerable<ClaimsIdentityEntity> entities)
        {
            foreach (var entity in entities)
                entity.Create();
            BaseRepository().Insert(entities.ToList());
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
            var expression = LinqExtensions.True<ClaimsIdentityEntity>();
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
        /// <param name="entity">ClaimsIdentityEntity</param>
        public void Remove(ClaimsIdentityEntity entity)
        {
            entity.Remove();
            BaseRepository().Update(entity);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities">List ClaimsIdentityEntity</param>
        public void Remove(IEnumerable<ClaimsIdentityEntity> entities)
        {
            foreach (var entity in entities)
                entity.Remove();
            BaseRepository().Update(entities.ToList());
        }


    }
}

