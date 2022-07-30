using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Data
{
    public interface IDatabase
    {
        IDatabase BeginTrans();

        Task<IDatabase> BeginTransAsync();
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
        void RollbackAsync();
        void Close();
        void CloseAsync();
        int ExecuteBySql(string strSql);
        Task<int> ExecuteBySqlAsync(string strSql);

        int ExecuteBySql(string strSql, params DbParameter[] dbParameter);
        Task<int> ExecuteBySqlAsync(string strSql, params DbParameter[] dbParameter);

        int ExecuteByProc(string procName);
        Task<int> ExecuteByProcAsync(string procName);

        int ExecuteByProc(string procName, DbParameter[] dbParameter);
        Task<int> ExecuteByProcAsync(string procName, DbParameter[] dbParameter);

        int Insert<T>(T entity) where T : class;
        Task<int> InsertAsync<T>(T entity) where T : class;

        int Insert<T>(IEnumerable<T> entities) where T : class;
        Task<int> InsertAsync<T>(IEnumerable<T> entities) where T : class;

        int Delete<T>() where T : class;
        Task<int> DeleteAsync<T>() where T : class;

        int Delete<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;

        int Delete<T>(IEnumerable<T> entities) where T : class;
        Task<int> DeleteAsync<T>(IEnumerable<T> entities) where T : class;

        int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<int> DeleteAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();

        int Delete<T>(object? KeyValue) where T : class;
        Task<int> DeleteAsync<T>(object? KeyValue) where T : class;

        int Delete<T>(object[] KeyValue) where T : class;
        Task<int> DeleteAsync<T>(object[] KeyValue) where T : class;

        int Delete<T>(object propertyValue, string propertyName) where T : class;
        Task<int> DeleteAsync<T>(object propertyValue, string propertyName) where T : class;

        int Update<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;

        int Update<T>(IEnumerable<T> entities) where T : class;
        Task<int> UpdateAsync<T>(IEnumerable<T> entities) where T : class;

        int Update<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<int> UpdateAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();

        object FindObject(string strSql);
        Task<object> FindObjectAsync(string strSql);

        object FindObject(string strSql, DbParameter[] dbParameter);
        Task<object> FindObjectAsync(string strSql, DbParameter[] dbParameter);

        T FindEntity<T>(object? KeyValue) where T : class;
        Task<T> FindEntityAsync<T>(object? KeyValue) where T : class;

        T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<T> FindEntityAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();

        IQueryable<T> IQueryable<T>() where T : class, new();
        Task<IQueryable<T>> IQueryableAsync<T>() where T : class, new();

        IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<IQueryable<T>> IQueryableAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();

        IEnumerable<T> FindList<T>() where T : class, new();
        Task<IEnumerable<T>> FindListAsync<T>() where T : class, new();

        IEnumerable<T> FindList<T>(Func<T, object> orderby) where T : class, new();
        Task<IEnumerable<T>> FindListAsync<T>(Func<T, object> orderby) where T : class, new();

        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<IEnumerable<T>> FindListAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();

        IEnumerable<T> FindList<T>(string strSql) where T : class;
        Task<IEnumerable<T>> FindListAsync<T>(string strSql) where T : class;

        IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class;
        Task<IEnumerable<T>> FindListAsync<T>(string strSql, DbParameter[] dbParameter) where T : class;

        IEnumerable<T> FindList<T>(string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new();
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new();
        IEnumerable<T> FindList<T>(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class;
        IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class;

        DataTable FindStrTable(string strSql, DbParameter[] dbParameter);
        Task<DataTable> FindStrTableAsync(string strSql, DbParameter[] dbParameter);

        DataTable FindTable(string strSql);
        Task<DataTable> FindTableAsync(string strSql);

        DataTable FindTable(string strSql, DbParameter[] dbParameter);
        Task<DataTable> FindTableAsync(string strSql, DbParameter[] dbParameter);

        DataTable FindTable(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total);

        DataTable FindTable(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total);
    }
}
