using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using Application.Util;

namespace Application.Data.Repository
{
    public interface IRepository
    {
        IRepository BeginTrans();
        IRepository BeginTransAsync();
        void Commit();
        void CommitAsync();
        void Rollback();
        void RollbackAsync();


        int ExecuteBySql(string strSql);
        Task<int> ExecuteBySqlAsync(string strSql);
        int ExecuteBySql(string strSql, params DbParameter[] dbParameter);
        Task<int> ExecuteBySqlAsync(string strSql, params DbParameter[] dbParameter);
        int ExecuteByProc(string procName);
        Task<int> ExecuteByProcAsync(string procName);
        int ExecuteByProc(string procName, params DbParameter[] dbParameter);
        Task<int> ExecuteByProcAsync(string procName, params DbParameter[] dbParameter);

        int Insert<T>(T entity) where T : class;
        Task<int> InsertAsync<T>(T entity) where T : class;

        int Insert<T>(List<T> entity) where T : class;
        Task<int> InsertAsync<T>(List<T> entity) where T : class;

        int Delete<T>() where T : class;
        Task<int> DeleteAsync<T>() where T : class;

        int Delete<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;

        int Delete<T>(List<T> entity) where T : class;
        Task<int> DeleteAsync<T>(List<T> entity) where T : class;

        int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<int> DeleteAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();

        int Delete<T>(object keyValue) where T : class;
        Task<int> DeleteAsync<T>(object keyValue) where T : class;

        int Delete<T>(object[] keyValue) where T : class;
        Task<int> DeleteAsync<T>(object[] keyValue) where T : class;

        int Delete<T>(object propertyValue, string propertyName) where T : class;
        Task<int> DeleteAsync<T>(object propertyValue, string propertyName) where T : class;

        int Update<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;

        int Update<T>(List<T> entity) where T : class;
        Task<int> UpdateAsync<T>(List<T> entity) where T : class;

        int Update<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<int> UpdateAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();

        T FindEntity<T>(object keyValue) where T : class;
        Task<T> FindEntityAsync<T>(object keyValue) where T : class;
        T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<T> FindEntityAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();
        IQueryable<T> IQueryable<T>() where T : class, new();
        Task<IQueryable<T>> IQueryableAsync<T>() where T : class, new();
        IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<IQueryable<T>> IQueryableAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();
        IEnumerable<T> FindList<T>(string strSql) where T : class;
        Task<IEnumerable<T>> FindListAsync<T>(string strSql) where T : class;
        IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class;
        Task<IEnumerable<T>> FindListAsync<T>(string strSql, DbParameter[] dbParameter) where T : class;
        IEnumerable<T> FindList<T>(Pagination pagination) where T : class, new();
        Task<IEnumerable<T>> FindListAsync<T>(Pagination pagination) where T : class, new();
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, Pagination pagination) where T : class, new();
        Task<IEnumerable<T>> FindListAsync<T>(Expression<Func<T, bool>> condition, Pagination pagination) where T : class, new();
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<IEnumerable<T>> FindListAsync<T>(Expression<Func<T, bool>> condition) where T : class, new();
        IEnumerable<T> FindList<T>(string strSql, Pagination pagination) where T : class;
        Task<IEnumerable<T>> FindListAsync<T>(string strSql, Pagination pagination) where T : class;
        IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, Pagination pagination) where T : class;
        Task<IEnumerable<T>> FindListAsync<T>(string strSql, DbParameter[] dbParameter, Pagination pagination) where T : class;
        DataTable FindStrTable(string strSql, DbParameter[] dbParameter);
        Task<DataTable> FindStrTableAsync(string strSql, DbParameter[] dbParameter);
        DataTable FindTable(string strSql);
        Task<DataTable> FindTableAsync(string strSql);
        DataTable FindTable(string strSql, DbParameter[] dbParameter);
        Task<DataTable> FindTableAsync(string strSql, DbParameter[] dbParameter);
        DataTable FindTable(string strSql, Pagination pagination);
        Task<DataTable> FindTableAsync(string strSql, Pagination pagination);
        DataTable FindTable(string strSql, DbParameter[] dbParameter, Pagination pagination);
        Task<DataTable> FindTableAsync(string strSql, DbParameter[] dbParameter, Pagination pagination);
        object FindObject(string strSql);
        Task<object> FindObjectAsync(string strSql);
        object FindObject(string strSql, DbParameter[] dbParameter);
        Task<object> FindObjectAsync(string strSql, DbParameter[] dbParameter);
    }
}
