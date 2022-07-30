using System;
namespace Application.Data.Repository
{
    public class RepositoryFactory<T> where T : class, new()
    {

        #region 数据库名称配置
        ///// <summary>
        ///// 主数据库
        ///// </summary>
        //public string baseDbKey = DbFactory.GetBaseDbKey();
        //public string unitId = DbFactory.GetUnitId();
        ///// <summary>
        ///// 用户数据库
        ///// </summary>
        //public string userDbName = Config.GetValue("UserDbName");
        //public string mainDbName = DbFactory.GetDbName();

        #endregion

        /// <summary>
        /// 定义仓储
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        //public IRepository<T> BaseRepository(string connString)
        //{
        //    return new Repository<T>(DbFactory.Base(connString, DatabaseType.SqlServer));
        //}
        /// <summary>
        /// 定义仓储（基础库）
        /// </summary>
        /// <returns></returns>
        public IRepository<T> BaseRepository()
        {
            return new Repository<T>(DbFactory.Base());
        }

        
    }
}
