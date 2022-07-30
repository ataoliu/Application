using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using Application.Util;

namespace Application.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        #region 构造
        public IDatabase db;
        public Repository(IDatabase idatabase)
        {
            this.db = idatabase;
        }
        #endregion

        #region 事物提交



        public IRepository<T> BeginTrans()
        {
            db.BeginTrans();
            return this;
        }
        public IRepository<T> BeginTransAsync()
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
            db.Rollback();
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
        public int Insert(T entity)
        {
            return db.Insert<T>(entity);
        }
        public async Task<int> InsertAsync(T entity)
        {
            return await db.InsertAsync<T>(entity);
        }
        public int Insert(List<T> entities)
        {
            return db.Insert<T>(entities);
        }
        public async Task<int> InsertAsync(List<T> entities)
        {
            return await db.InsertAsync<T>(entities);
        }
        public async Task<int> DeleteAsync()
        {
            return await db.DeleteAsync<T>();
        }


        public int Delete(T entity)
        {
            return db.Delete<T>(entity);
        }
        public async Task<int> DeleteAsync(T entity)
        {
            return await db.DeleteAsync<T>(entity);
        }

        public int Delete(List<T> entity)
        {
            return db.Delete<T>(entity);
        }
        public async Task<int> DeleteAsync(List<T> entity)
        {
            return await db.DeleteAsync<T>(entity);
        }

        public int Delete(Expression<Func<T, bool>> condition)
        {
            return db.Delete<T>(condition);
        }
        public async Task<int> DeleteAsync(Expression<Func<T, bool>> condition)
        {
            return await db.DeleteAsync<T>(condition);
        }

        public int Delete(object? keyValue)
        {
            return db.Delete<T>(keyValue);
        }
        public async Task<int> DeleteAsync(object? keyValue)
        {
            return await db.DeleteAsync<T>(keyValue);

        }
        public int Delete(object[] keyValue)
        {
            return db.Delete<T>(keyValue);
        }
        public async Task<int> DeleteAsync(object[] keyValue)
        {
            return await db.DeleteAsync<T>(keyValue);
        }

        public int Delete(object propertyValue, string propertyName)
        {
            return db.Delete<T>(propertyValue, propertyName);
        }
        public async Task<int> DeleteAsync(object propertyValue, string propertyName)
        {
            return await db.DeleteAsync<T>(propertyValue, propertyName);
        }

        public int Update(T entity)
        {
            return db.Update<T>(entity);
        }
        public async Task<int> UpdateAsync(T entity)
        {
            return await db.UpdateAsync<T>(entity);
        }

        public int Update(List<T> entities)
        {
            return db.Update<T>(entities);
        }
        public async Task<int> UpdateAsync(List<T> entities)
        {
            return await db.UpdateAsync<T>(entities);
        }
        public int Update(Expression<Func<T, bool>> condition)
        {
            return db.Update<T>(condition);
        }
        public async Task<int> UpdateAsync(Expression<Func<T, bool>> condition)
        {
            return await db.UpdateAsync<T>(condition);
        }
        #endregion

        #region 对象实体 查询

        public T FindEntity(object? keyValue)
        {
            return db.FindEntity<T>(keyValue);
        }
        public async Task<T> FindEntityAsync(object? keyValue)
        {
            return await db.FindEntityAsync<T>(keyValue);
        }

        public T FindEntity(Expression<Func<T, bool>> condition)
        {
            return db.FindEntity<T>(condition);
        }
        public async Task<T> FindEntityAsync(Expression<Func<T, bool>> condition)
        {
            return await db.FindEntityAsync<T>(condition);
        }

        public IQueryable<T> IQueryable()
        {
            return db.IQueryable<T>();
        }
        public async Task<IQueryable<T>> IQueryableAsync()
        {
            return await db.IQueryableAsync<T>();
        }

        public IQueryable<T> IQueryable(Expression<Func<T, bool>> condition)
        {
            return db.IQueryable<T>(condition);
        }
        public async Task<IQueryable<T>> IQueryableAsync(Expression<Func<T, bool>> condition)
        {
            return await db.IQueryableAsync<T>(condition);
        }

        public IEnumerable<T> FindList()
        {
            return db.FindList<T>();
        }
        public async Task<IEnumerable<T>> FindListAsync()
        {
            return await db.FindListAsync<T>();
        }

        public IEnumerable<T> FindList(string strSql)
        {
            return db.FindList<T>(strSql);
        }

        public async Task<IEnumerable<T>> FindListAsync(string strSql)
        {
            return await db.FindListAsync<T>(strSql);
        }

        public IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter)
        {
            return db.FindList<T>(strSql, dbParameter);
        }
        public async Task<IEnumerable<T>> FindListAsync(string strSql, DbParameter[] dbParameter)
        {
            return await db.FindListAsync<T>(strSql, dbParameter);
        }
        public IEnumerable<T> FindList(Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindList<T>(pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<IEnumerable<T>> FindListAsync(Pagination pagination)
        {
            return await Task.Run(() =>
            {
                int total = pagination.records;
                var data = db.FindList<T>(pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                pagination.records = total;
                return data;
            });
        }
        public IEnumerable<T> FindList(Expression<Func<T, bool>> condition, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindList<T>(condition, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> condition, Pagination pagination)
        {
            return await Task.Run(() =>
            {
                int total = pagination.records;
                var data = db.FindList<T>(condition, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                pagination.records = total;
                return data;
            });
        }
        public IEnumerable<T> FindList(string strSql, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindList<T>(strSql, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<IEnumerable<T>> FindListAsync(string strSql, Pagination pagination)
        {
            return await Task.Run(() =>
            {
                int total = pagination.records;
                var data = db.FindList<T>(strSql, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
                pagination.records = total;
                return data;
            });
        }

        public IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindList<T>(strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public async Task<IEnumerable<T>> FindListAsync(string strSql, DbParameter[] dbParameter, Pagination pagination)
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
