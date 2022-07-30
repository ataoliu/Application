using System;
namespace Application.Data.Repository
{
    public class RepositoryFactory
    {
      //private  IRepository _repository;
      //  //private IDatabase _database;
      // public RepositoryFactory(Repository repository,)
      //  {
      //      _repository = repository.CreateDataBase();
      //  }
        /// <summary>
        /// 定义仓储
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        //public IRepository BaseRepository(string connString)
        //{
        //    return new Repository(DbFactory.Base(connString, DatabaseType.SqlServer));
        //}
        ///// <summary>
        ///// 定义仓储（基础库）
        ///// </summary>
        ///// <returns></returns>
        public IRepository BaseRepository()
        {
            return new Repository(DbFactory.Base());
        }

    }
}
