using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using Application.Util;
namespace Application.Data.Repository
{
    public class Repository : IRepository
    {
        #region 构造
        public IDatabase db;
        public Repository(IDatabase database)
        {
            this.db = database;
        }

        public void CreateDataBase(IDatabase database)
        {
            this.db = database;
        }
        #endregion

        #region 事物提交
        public IRepository BeginTrans()
        {
            db.BeginTrans();
            return this;
        }
        public IRepository BeginTransAsync()
        {
            db.BeginTransAsync();
            return this;
        }
        public void Commit()
        {
            db.Commit();
        }
        public void CommitAsync()
        {
            db.CommitAsync();
        }
        public void Rollback()
        {
            db.RollbackAsync();
        }
        public void RollbackAsync()
        {
            db.RollbackAsync();
        }
        #endregion

        #region 执行 SQL 语句
        public int ExecuteBySql(string strSql)
        {
            return db.ExecuteBySql(strSql);
        }
        public async Task<int> ExecuteBySqlAsync(string strSql)
        {
            return await db.ExecuteBySqlAsync(strSql);
        }
        public int ExecuteBySql(string strSql, params DbParameter[] dbParameter)
        {
            return db.ExecuteBySql(strSql, dbParameter);
        }
        public async Task<int> ExecuteBySqlAsync(string strSql, params DbParameter[] dbParameter)
        {
            return await db.ExecuteBySqlAsync(strSql, dbParameter);
        }
        public int ExecuteByProc(string procName)
        {
            return db.ExecuteByProc(procName);
        }
        public async Task<int> ExecuteByProcAsync(string procName)
        {
            return await db.ExecuteByProcAsync(procName);
        }
        public int ExecuteByProc(string procName, params DbParameter[] dbParameter)
        {
            return db.ExecuteByProc(procName, dbParameter);
        }
        public async Task<int> ExecuteByProcAsync(string procName, params DbParameter[] dbParameter)
        {
            return await db.ExecuteByProcAsync(procName, dbParameter);
        }
        #endregion

        #region 对象实体 添加、修改、删除
        public int Insert<T>(T entity) where T : class
        {
            return db.Insert<T>(entity);
        }
        public async Task<int> InsertAsync<T>(T entity) where T : class
        {
            return await db.InsertAsync<T>(entity);
        }
        public int Insert<T>(List<T> entity) where T : class
        {
            return db.Insert<T>(entity);
        }
        public async Task<int> InsertAsync<T>(List<T> entity) where T : class
        {
            return await db.InsertAsync<T>(entity);
        }
        public int Delete<T>() where T : class
        {
            return db.Delete<T>();
        }
        public async Task<int> DeleteAsync<T>() where T : class
        {
            return await db.DeleteAsync<T>();
        }
        public int Delete<T>(T entity) where T : class
        {
            return db.Delete<T>(entity);
        }
        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            return await db.DeleteAsync<T>(entity);
        }
        public int Delete<T>(List<T> entity) where T : class
        {
            return db.Delete<T>(entity);
        }
        public async Task<int> DeleteAsync<T>(List<T> entity) where T : class
        {
            return await db.DeleteAsync<T>(entity);
        }
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.Delete<T>(condition);
        }
        public async Task<int> DeleteAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.DeleteAsync<T>(condition);
        }
        public int Delete<T>(object keyValue) where T : class
        {
            return db.Delete<T>(keyValue);
        }
        public async Task<int> DeleteAsync<T>(object keyValue) where T : class
        {
            return await db.DeleteAsync<T>(keyValue);
        }
        public int Delete<T>(object[] keyValue) where T : class
        {
            return db.Delete<T>(keyValue);
        }
        public async Task<int> DeleteAsync<T>(object[] keyValue) where T : class
        {
            return await db.DeleteAsync<T>(keyValue);
        }
        public int Delete<T>(object propertyValue, string propertyName) where T : class
        {
            return db.Delete<T>(propertyValue, propertyName);
        }
        public async Task<int> DeleteAsync<T>(object propertyValue, string propertyName) where T : class
        {
            return await db.DeleteAsync<T>(propertyValue, propertyName);
        }
        public int Update<T>(T entity) where T : class
        {
            return db.Update<T>(entity);
        }
        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            return await db.UpdateAsync<T>(entity);
        }
        public int Update<T>(List<T> entity) where T : class
        {
            return db.Update<T>(entity);
        }
        public async Task<int> UpdateAsync<T>(List<T> entity) where T : class
        {
            return await db.UpdateAsync<T>(entity);
        }

        public int Update<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.Update<T>(condition);
        }
        public async Task<int> UpdateAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.UpdateAsync<T>(condition);
        }
        #endregion

        #region 对象实体 查询
        public T FindEntity<T>(object keyValue) where T : class
        {
            return db.FindEntity<T>(keyValue);
        }
        public async Task<T> FindEntityAsync<T>(object keyValue) where T : class
        {
            return await db.FindEntityAsync<T>(keyValue);
        }
        public T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.FindEntity<T>(condition);
        }
        public async Task<T> FindEntityAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.FindEntityAsync<T>(condition);
        }
        public IQueryable<T> IQueryable<T>() where T : class, new()
        {
            return db.IQueryable<T>();
        }
        public async Task<IQueryable<T>> IQueryableAsync<T>() where T : class, new()
        {
            return await db.IQueryableAsync<T>();
        }
        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.IQueryable<T>(condition);
        }
        public async Task<IQueryable<T>> IQueryableAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.IQueryableAsync<T>(condition);
        }
        public IEnumerable<T> FindList<T>() where T : class, new()
        {
            return db.FindList<T>();
        }
        public async Task<IEnumerable<T>> FindListAsync<T>() where T : class, new()
        {
            return await db.FindListAsync<T>();
        }
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.FindList<T>(condition);
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.FindListAsync<T>(condition);
        }
        public IEnumerable<T> FindList<T>(string strSql) where T : class
        {
            return db.FindList<T>(strSql);
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(string strSql) where T : class
        {
            return await db.FindListAsync<T>(strSql);
        }
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class
        {
            return db.FindList<T>(strSql, dbParameter);
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(string strSql, DbParameter[] dbParameter) where T : class
        {
            return await db.FindListAsync<T>(strSql, dbParameter);
        }
        public IEnumerable<T> FindList<T>(Pagination pagination) where T : class, new()
        {
            int total = pagination.records;
            var data = db.FindList<T>(pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(Pagination pagination) where T : class, new()
        {
            return await Task.Run(() =>
             {
                 int total = pagination.records;
                 var data = db.FindList<T>(pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                 pagination.records = total;
                 return data;
             });
        }
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, Pagination pagination) where T : class, new()
        {
            int total = pagination.records;
            var data = db.FindList<T>(condition, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(Expression<Func<T, bool>> condition, Pagination pagination) where T : class, new()
        {
            return await Task.Run(() =>
             {
                 int total = pagination.records;
                 var data = db.FindList<T>(condition, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                 pagination.records = total;
                 return data;
             });

        }
        public IEnumerable<T> FindList<T>(string strSql, Pagination pagination) where T : class
        {
            int total = pagination.records;
            var data = db.FindList<T>(strSql, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(string strSql, Pagination pagination) where T : class
        {
            return await Task.Run(() =>
            {
                int total = pagination.records;
                var data = db.FindList<T>(strSql, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                pagination.records = total;
                return data;
            });

        }
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, Pagination pagination) where T : class
        {
            int total = pagination.records;
            var data = db.FindList<T>(strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(string strSql, DbParameter[] dbParameter, Pagination pagination) where T : class
        {
            return await Task.Run(() =>
            {
                int total = pagination.records;
                var data = db.FindList<T>(strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                pagination.records = total;
                return data;
            });

        }
        #endregion

        #region 数据源 查询
        public DataTable FindStrTable(string strSql, DbParameter[] dbParameter)
        {
            return db.FindStrTable(strSql, dbParameter);
        }
        public async Task<DataTable> FindStrTableAsync(string strSql, DbParameter[] dbParameter)
        {
            return await db.FindStrTableAsync(strSql, dbParameter);
        }
        public DataTable FindTable(string strSql)
        {
            return db.FindTable(strSql);
        }
        public async Task<DataTable> FindTableAsync(string strSql)
        {
            return await db.FindTableAsync(strSql);
        }
        public DataTable FindTable(string strSql, DbParameter[] dbParameter)
        {
            return db.FindTable(strSql, dbParameter);
        }
        public async Task<DataTable> FindTableAsync(string strSql, DbParameter[] dbParameter)
        {
            return await db.FindTableAsync(strSql, dbParameter);
        }
        public DataTable FindTable(string strSql, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindTable(strSql, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<DataTable> FindTableAsync(string strSql, Pagination pagination)
        {
            return await Task.Run(() =>
             {
                 int total = pagination.records;
                 var data = db.FindTable(strSql, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                 pagination.records = total;
                 return data;
             });

        }
        public DataTable FindTable(string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindTable(strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<DataTable> FindTableAsync(string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            return await Task.Run(() =>
            {
                int total = pagination.records;
                var data = db.FindTable(strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                pagination.records = total;
                return data;
            });

        }
        public object FindObject(string strSql)
        {
            return db.FindObject(strSql);
        }
        public async Task<object> FindObjectAsync(string strSql)
        {
            return await db.FindObjectAsync(strSql);
        }
        public object FindObject(string strSql, DbParameter[] dbParameter)
        {
            return db.FindObject(strSql, dbParameter);
        }
        public async Task<object> FindObjectAsync(string strSql, DbParameter[] dbParameter)
        {
            return await db.FindObjectAsync(strSql, dbParameter);
        }
        #endregion
    }
}
