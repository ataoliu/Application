using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using Application.Util;

namespace Application.Data.Repository
{
    public interface IRepository<T> where T : class, new()
    {
        IRepository<T> BeginTrans();
        IRepository<T> BeginTransAsync();
        void Commit();
        void CommitAsync();
        void Rollback();
        void RollbackAsync();

        Task<int> ExecuteBySqlAsync(string strSql);
        int ExecuteBySql(string strSql);

        int ExecuteBySql(string strSql, params DbParameter[] dbParameter);
        Task<int> ExecuteBySqlAsync(string strSql, params DbParameter[] dbParameter);
        int ExecuteByProc(string procName);
        Task<int> ExecuteByProcAsync(string procName);
        int ExecuteByProc(string procName, params DbParameter[] dbParameter);
        Task<int> ExecuteByProcAsync(string procName, params DbParameter[] dbParameter);

        int Insert(T entity);
        Task<int> InsertAsync(T entity);

        int Insert(List<T> entities);
        Task<int> InsertAsync(List<T> entities);

        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        int Delete(List<T> entity);
        Task<int> DeleteAsync(List<T> entity);
        int Delete(Expression<Func<T, bool>> condition);
        Task<int> DeleteAsync(Expression<Func<T, bool>> condition);
        int Delete(object? keyValue);
        Task<int> DeleteAsync(object? keyValue);
        int Delete(object[] keyValue);
        Task<int> DeleteAsync(object[] keyValue);
        int Delete(object propertyValue, string propertyName);
        Task<int> DeleteAsync(object propertyValue, string propertyName);
        int Update(T entity);
        Task<int> UpdateAsync(T entity);
        int Update(List<T> entities);
        Task<int> UpdateAsync(List<T> entities);
        int Update(Expression<Func<T, bool>> condition);
        Task<int> UpdateAsync(Expression<Func<T, bool>> condition);

        T FindEntity(object? keyValue);
        Task<T> FindEntityAsync(object? keyValue);
        T FindEntity(Expression<Func<T, bool>> condition);
        Task<T> FindEntityAsync(Expression<Func<T, bool>> condition);
        IQueryable<T> IQueryable();
        Task<IQueryable<T>> IQueryableAsync();
        IQueryable<T> IQueryable(Expression<Func<T, bool>> condition);
        Task<IQueryable<T>> IQueryableAsync(Expression<Func<T, bool>> condition);
        IEnumerable<T> FindList();
        Task<IEnumerable<T>> FindListAsync();
        IEnumerable<T> FindList(string strSql);
        Task<IEnumerable<T>> FindListAsync(string strSql);
        IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter);
        Task<IEnumerable<T>> FindListAsync(string strSql, DbParameter[] dbParameter);
        IEnumerable<T> FindList(Pagination pagination);
        Task<IEnumerable<T>> FindListAsync(Pagination pagination);
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition, Pagination pagination);
        Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> condition, Pagination pagination);
        IEnumerable<T> FindList(string strSql, Pagination pagination);
        Task<IEnumerable<T>> FindListAsync(string strSql, Pagination pagination);
        IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter, Pagination pagination);
        Task<IEnumerable<T>> FindListAsync(string strSql, DbParameter[] dbParameter, Pagination pagination);

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
