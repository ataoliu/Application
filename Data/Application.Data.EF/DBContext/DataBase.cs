using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.EF
{
    public class DataBase : IDatabase
    {
        /// <summary>
        /// 获取 当前使用的数据访问上下文对象
        /// </summary>
        public DbContext db { get; set; }
        /// <summary>
        /// 事务对象
        /// </summary>
        public DbTransaction dbTransaction { get; set; }


        public DataBase()
        {
            db = new SqlServerDbContext();
        }
        #region 事务提交
        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns></returns>
        public IDatabase BeginTrans()
        {
            DbConnection dbConnection = ((IObjectContextAdapter)db).ObjectContext.Connection;
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            dbTransaction = dbConnection.BeginTransaction();
            return this;
        }
        public async Task<IDatabase> BeginTransAsync()
        {
            DbConnection dbConnection = ((IObjectContextAdapter)db).ObjectContext.Connection;
            if (dbConnection.State == ConnectionState.Closed)
            {
                await dbConnection.OpenAsync();
            }
            dbTransaction = await dbConnection.BeginTransactionAsync();
            return this;
        }
        /// <summary>
        /// 提交当前操作的结果
        /// </summary>
        public int Commit()
        {
            try
            {
                int returnValue = db.SaveChanges();
                if (dbTransaction != null)
                {
                    dbTransaction.Commit();
                    this.Close();
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = ex.InnerException.InnerException as SqlException;
                }
                throw;
            }
            finally
            {
                if (dbTransaction == null)
                {
                    this.Close();
                }
            }
        }
        public async Task<int> CommitAsync()
        {
            try
            {
                int returnValue = await db.SaveChangesAsync();
                if (dbTransaction != null)
                {
                    await dbTransaction.CommitAsync();
                    this.CloseAsync();
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = ex.InnerException.InnerException as SqlException;
                }
                throw;
            }
            finally
            {
                if (dbTransaction == null)
                {
                    this.CloseAsync();
                }
            }
        }
        /// <summary>
        /// 把当前操作回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            this.dbTransaction.Rollback();
            this.dbTransaction.Dispose();
            this.Close();
        }
        public void RollbackAsync()
        {
            this.dbTransaction.RollbackAsync();
            this.dbTransaction.DisposeAsync();
            this.CloseAsync();
        }
        /// <summary>
        /// 关闭连接 内存回收
        /// </summary>
        public void Close()
        {

            db.Dispose();
        }
        public void CloseAsync()
        {
            db.DisposeAsync();
        }
        #endregion

        #region 执行 SQL 语句
        public int ExecuteBySql(string strSql)
        {
            if (dbTransaction == null)
            {
                return db.Database.ExecuteSqlRaw(strSql);
            }
            else
            {
                db.Database.ExecuteSqlRaw(strSql);
                return dbTransaction == null ? this.Commit() : 0;
            }
        }

        public async Task<int> ExecuteBySqlAsync(string strSql)
        {
            if (dbTransaction == null)
            {
                return await db.Database.ExecuteSqlRawAsync(strSql);
            }
            else
            {
                await db.Database.ExecuteSqlRawAsync(strSql);
                return dbTransaction == null ? await this.CommitAsync() : 0;
            }
        }
        public int ExecuteBySql(string strSql, params DbParameter[] dbParameter)
        {
            if (dbTransaction == null)
            {
                return db.Database.ExecuteSqlRaw(strSql, dbParameter);
            }
            else
            {
                db.Database.ExecuteSqlRaw(strSql, dbParameter);
                return dbTransaction == null ? this.Commit() : 0;
            }
        }
        public async Task<int> ExecuteBySqlAsync(string strSql, params DbParameter[] dbParameter)
        {
            if (dbTransaction == null)
            {
                return await db.Database.ExecuteSqlRawAsync(strSql, dbParameter);
            }
            else
            {
                await db.Database.ExecuteSqlRawAsync(strSql, dbParameter);
                return dbTransaction == null ? await this.CommitAsync() : 0;
            }
        }

        public int ExecuteByProc(string procName)
        {
            if (dbTransaction == null)
            {
                // var connection=  db.Database.GetDbConnection();
                return db.Database.ExecuteSqlRaw(procName);
            }
            else
            {
                db.Database.ExecuteSqlRaw(procName);
                return dbTransaction == null ? this.Commit() : 0;
            }
        }
        public async Task<int> ExecuteByProcAsync(string procName)
        {
            if (dbTransaction == null)
            {
                // var connection=  db.Database.GetDbConnection();
                return await db.Database.ExecuteSqlRawAsync(procName);
            }
            else
            {
                await db.Database.ExecuteSqlRawAsync(procName);
                return dbTransaction == null ? await this.CommitAsync() : 0;
            }
        }

        public int ExecuteByProc(string procName, params DbParameter[] dbParameter)
        {
            if (dbTransaction == null)
            {
                var connection = db.Database.GetDbConnection();
                using (var cmd = connection.CreateCommand())
                {
                    db.Database.OpenConnectionAsync();
                    cmd.CommandText = procName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(dbParameter);
                    return cmd.ExecuteNonQuery();
                }
            }
            else
            {
                var connection = db.Database.GetDbConnection();
                using (var cmd = connection.CreateCommand())
                {
                    db.Database.OpenConnectionAsync();
                    cmd.CommandText = procName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(dbParameter);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public async Task<int> ExecuteByProcAsync(string procName, params DbParameter[] dbParameter)
        {
            if (dbTransaction == null)
            {
                var connection = db.Database.GetDbConnection();
                using (var cmd = connection.CreateCommand())
                {
                    await db.Database.OpenConnectionAsync();
                    cmd.CommandText = procName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(dbParameter);
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
            else
            {
                var connection = db.Database.GetDbConnection();
                using (var cmd = connection.CreateCommand())
                {
                    await db.Database.OpenConnectionAsync();
                    cmd.CommandText = procName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(dbParameter);
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion

        #region 对象实体 添加、修改、删除
        public int Insert<T>(T entity) where T : class
        {
            db.Entry<T>(entity).State = EntityState.Added;
            return dbTransaction == null ? this.Commit() : 0;
        }
        public async Task<int> InsertAsync<T>(T entity) where T : class
        {
            await db.AddAsync(entity);
            //db.Entry<T>(entity).State = EntityState.Added;
            return dbTransaction == null ? await this.CommitAsync() : 0;
        }

        public int Insert<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                db.Entry<T>(entity).State = EntityState.Added;
            }
            return dbTransaction == null ? this.Commit() : 0;
        }
        public async Task<int> InsertAsync<T>(IEnumerable<T> entities) where T : class
        {
            //foreach (var entity in entities)
            //{
            //    db.Entry<T>(entity).State = EntityState.Added;
            //}
            await db.AddRangeAsync(entities);
            return dbTransaction == null ? await this.CommitAsync() : 0;
        }

        public int Delete<T>() where T : class
        {
            EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(db);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                return this.ExecuteBySql(DbContextExtensions.DeleteSql(tableName));
            }
            return -1;
        }
        public async Task<int> DeleteAsync<T>() where T : class
        {
            return await Task.Run(async () =>
              {
                  EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(db);
                  if (entitySet != null)
                  {
                      string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                                    ? entitySet.MetadataProperties["Table"].Value.ToString()
                                    : entitySet.Name;
                      return await this.ExecuteBySqlAsync(DbContextExtensions.DeleteSql(tableName));
                  }
                  return -1;
              });
        }

        public int Delete<T>(T entity) where T : class
        {
            db.Set<T>().Attach(entity);
            db.Set<T>().Remove(entity);
            return dbTransaction == null ? this.Commit() : 0;
        }
        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            return await Task.Run(async () =>
             {
                 db.Set<T>().Attach(entity);
                 db.Set<T>().Remove(entity);
                 return dbTransaction == null ? await this.CommitAsync() : 0;
             });

        }

        public int Delete<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                db.Set<T>().Attach(entity);
                db.Set<T>().Remove(entity);
            }
            return dbTransaction == null ? this.Commit() : 0;
        }
        public async Task<int> DeleteAsync<T>(IEnumerable<T> entities) where T : class
        {
            await Task.Run(() =>
            {
                foreach (var entity in entities)
                {
                    db.Set<T>().Attach(entity);
                    db.Set<T>().Remove(entity);
                }
            });
            return dbTransaction == null ? await this.CommitAsync() : 0;
        }

        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            IEnumerable<T> entities = db.Set<T>().Where(condition).ToList();
            return entities.Count() > 0 ? Delete(entities) : 0;
        }
        public async Task<int> DeleteAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await Task.Run(async () =>
            {
                IEnumerable<T> entities = db.Set<T>().Where(condition).ToList();
                return entities.Count() > 0 ? await DeleteAsync(entities) : 0;
            });
        }

        public int Delete<T>(object? keyValue) where T : class
        {
            EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(db);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                string keyFlied = entitySet.ElementType.KeyMembers[0].Name;
                return this.ExecuteBySql(DbContextExtensions.DeleteSql(tableName, keyFlied, keyValue));
            }
            return -1;
        }
        public async Task<int> DeleteAsync<T>(object? keyValue) where T : class
        {
            return await Task.Run(async () =>
            {
                EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(db);
                if (entitySet != null)
                {
                    string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                                   ? entitySet.MetadataProperties["Table"].Value.ToString()
                                   : entitySet.Name;
                    string keyFlied = entitySet.ElementType.KeyMembers[0].Name;
                    return await this.ExecuteBySqlAsync(DbContextExtensions.DeleteSql(tableName, keyFlied, keyValue));
                }
                return -1;
            });
        }

        public int Delete<T>(object[] keyValue) where T : class
        {
            EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(db);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                string keyFlied = entitySet.ElementType.KeyMembers[0].Name;
                return this.ExecuteBySql(DbContextExtensions.DeleteSql(tableName, keyFlied, keyValue));
            }
            return -1;
        }
        public async Task<int> DeleteAsync<T>(object[] keyValue) where T : class
        {
            return await Task.Run(async () =>
            {
                EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(db);
                if (entitySet != null)
                {
                    string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                                   ? entitySet.MetadataProperties["Table"].Value.ToString()
                                   : entitySet.Name;
                    string keyFlied = entitySet.ElementType.KeyMembers[0].Name;
                    return await this.ExecuteBySqlAsync(DbContextExtensions.DeleteSql(tableName, keyFlied, keyValue));
                }
                return -1;
            });

        }

        public int Delete<T>(object propertyValue, string propertyName) where T : class
        {
            EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(db);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                return this.ExecuteBySql(DbContextExtensions.DeleteSql(tableName, propertyName, propertyValue));
            }
            return -1;
        }
        public async Task<int> DeleteAsync<T>(object propertyValue, string propertyName) where T : class
        {
            return await Task.Run(async () =>
            {
                EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(db);
                if (entitySet != null)
                {
                    string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                                   ? entitySet.MetadataProperties["Table"].Value.ToString()
                                   : entitySet.Name;
                    return await this.ExecuteBySqlAsync(DbContextExtensions.DeleteSql(tableName, propertyName, propertyValue));
                }
                return -1;
            });

        }

        public int Update<T>(T entity) where T : class
        {
            db.Set<T>().Attach(entity);
            Hashtable props = ConvertExtension.GetPropertyInfo<T>(entity);
            foreach (string item in props.Keys)
            {
                object value = db.Entry(entity).Property(item).CurrentValue;
                if (value != null && item != "Id")
                {
                    if (value.ToString() == "&nbsp;")
                        db.Entry(entity).Property(item).CurrentValue = null;
                    db.Entry(entity).Property(item).IsModified = true;
                }
            }
            return dbTransaction == null ? this.Commit() : 0;
        }
        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            return await Task.Run(async () =>
           {
               db.Set<T>().Attach(entity);
               Hashtable props = ConvertExtension.GetPropertyInfo<T>(entity);
               foreach (string item in props.Keys)
               {
                   object value = db.Entry(entity).Property(item).CurrentValue;
                   if (value != null && item != "Id")
                   {
                       if (value.ToString() == "&nbsp;")
                           db.Entry(entity).Property(item).CurrentValue = null;
                       db.Entry(entity).Property(item).IsModified = true;
                   }
               }
               return dbTransaction == null ? await this.CommitAsync() : 0;
           });
        }

        public int Update<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                db.Set<T>().Attach(entity);
                //  db.Entry(entity).State = EntityState.Modified;
                Hashtable props = ConvertExtension.GetPropertyInfo<T>(entity);
                foreach (string item in props.Keys)
                {
                    object value = db.Entry(entity).Property(item).CurrentValue;
                    if (value != null && item != "Id")
                    {
                        if (value.ToString() == "&nbsp;")
                            db.Entry(entity).Property(item).CurrentValue = null;
                        db.Entry(entity).Property(item).IsModified = true;
                    }
                }
            }
            return dbTransaction == null ? this.Commit() : 0;
        }
        public async Task<int> UpdateAsync<T>(IEnumerable<T> entities) where T : class
        {
            return await Task.Run(async () =>
            {
                foreach (var entity in entities)
                {
                    db.Set<T>().Attach(entity);
                    //  db.Entry(entity).State = EntityState.Modified;
                    Hashtable props = ConvertExtension.GetPropertyInfo<T>(entity);
                    foreach (string item in props.Keys)
                    {
                        object value = db.Entry(entity).Property(item).CurrentValue;
                        if (value != null && item != "Id")
                        {
                            if (value.ToString() == "&nbsp;")
                                db.Entry(entity).Property(item).CurrentValue = null;
                            db.Entry(entity).Property(item).IsModified = true;
                        }
                    }
                }
                return dbTransaction == null ? await this.CommitAsync() : 0;
            });
        }

        public int Update<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            IEnumerable<T> entities = db.Set<T>().Where(condition).ToList();
            return entities.Count() > 0 ? Update(entities) : 0;
        }
        public async Task<int> UpdateAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await Task.Run(async () =>
            {
                IEnumerable<T> entities = db.Set<T>().Where(condition).ToList();
                return entities.Count() > 0 ? await UpdateAsync(entities) : 0;
            });
        }
        #endregion
        #region 对象实体 查询
        public T FindEntity<T>(object? keyValue) where T : class
        {
            return db.Set<T>().Find(keyValue);
        }
        public async Task<T> FindEntityAsync<T>(object? keyValue) where T : class
        {
            return await db.Set<T>().FindAsync(keyValue);
        }

        public T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.Set<T>().Where(condition).FirstOrDefault();
        }
        public async Task<T> FindEntityAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await Task.Run(() =>
            {
                return db.Set<T>().Where(condition).FirstOrDefault();
            });
        }

        public IQueryable<T> IQueryable<T>() where T : class, new()
        {
            return db.Set<T>();
        }
        public async Task<IQueryable<T>> IQueryableAsync<T>() where T : class, new()
        {
            return await Task.Run(() =>
            {
                return db.Set<T>();
            });
        }

        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.Set<T>().Where(condition);
        }
        public async Task<IQueryable<T>> IQueryableAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await Task.Run(() =>
            {
                return db.Set<T>().Where(condition);
            });
        }

        public IEnumerable<T> FindList<T>() where T : class, new()
        {
            return db.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> FindListAsync<T>() where T : class, new()
        {
            return await Task.Run(() =>
            {
                return db.Set<T>().ToList();
            });
        }

        public IEnumerable<T> FindList<T>(Func<T, object> keySelector) where T : class, new()
        {
            return db.Set<T>().OrderBy(keySelector).ToList();
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(Func<T, object> keySelector) where T : class, new()
        {
            return await Task.Run(() =>
            {
                return db.Set<T>().OrderBy(keySelector).ToList();
            });
        }

        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.Set<T>().Where(condition).ToList();
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await Task.Run(() =>
            {
                return db.Set<T>().Where(condition).ToList();
            });
        }

        public IEnumerable<T> FindList<T>(string strSql) where T : class
        {
            return FindList<T>(strSql, null);
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(string strSql) where T : class
        {
            return await Task.Run(async () =>
            {
                return await FindListAsync<T>(strSql, null);
            });
        }

        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class
        {
            using (var dbConnection = db.Database.GetDbConnection())
            {
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter);
                return ConvertExtension.IDataReaderToList<T>(IDataReader);
            }
        }
        public async Task<IEnumerable<T>> FindListAsync<T>(string strSql, DbParameter[] dbParameter) where T : class
        {
            return await Task.Run(() =>
            {
                using (var dbConnection = db.Database.GetDbConnection())
                {
                    var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter);
                    return ConvertExtension.IDataReaderToList<T>(IDataReader);
                }
            });
        }

        public IEnumerable<T> FindList<T>(string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            string[] _order = orderField.Split(',');
            MethodCallExpression resultExp = null;
            var tempData = db.Set<T>().AsQueryable();
            foreach (string item in _order)
            {
                string _orderPart = item;
                _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                string[] _orderArry = _orderPart.Split(' ');
                string _orderField = _orderArry[0];
                bool sort = isAsc;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(T), "t");
                var property = typeof(T).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }
            tempData = tempData.Provider.CreateQuery<T>(resultExp);
            total = tempData.Count();
            tempData = tempData.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            return tempData.ToList();
        }

        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            string[] _order = orderField.Split(',');
            MethodCallExpression resultExp = null;
            var tempData = db.Set<T>().Where(condition);
            foreach (string item in _order)
            {
                string _orderPart = item;
                _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                string[] _orderArry = _orderPart.Split(' ');
                string _orderField = _orderArry[0];
                bool sort = isAsc;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(T), "t");
                var property = typeof(T).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }
            tempData = tempData.Provider.CreateQuery<T>(resultExp);
            total = tempData.Count();
            tempData = tempData.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            return tempData.ToList();
        }
        public IEnumerable<T> FindList<T>(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class
        {
            return FindList<T>(strSql, null, orderField, isAsc, pageSize, pageIndex, out total);
        }
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class
        {
            using (var dbConnection = db.Database.GetDbConnection())
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string OrderBy = "";

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC") + orderField.ToUpper().IndexOf("DESC") > 0)
                    {
                        OrderBy = "Order By " + orderField;
                    }
                    else
                    {
                        OrderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    OrderBy = "order by (select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + OrderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                total = Convert.ToInt32(new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, "Select Count(1) From (" + strSql + ") As t", dbParameter));
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, sb.ToString(), dbParameter);
                return ConvertExtension.IDataReaderToList<T>(IDataReader);
            }
        }
        #endregion

        #region 数据源查询
        public DataTable FindStrTable(string strSql, DbParameter[] dbParameter)
        {
            using (var dbConnection = db.Database.GetDbConnection())
            {
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter);
                return ConvertExtension.IDataReaderToStringTable(IDataReader);
            }
        }
        public async Task<DataTable> FindStrTableAsync(string strSql, DbParameter[] dbParameter)
        {
            return await Task.Run(() =>
            {
                using (var dbConnection = db.Database.GetDbConnection())
                {
                    var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter);
                    return ConvertExtension.IDataReaderToStringTable(IDataReader);
                }
            });
        }

        public DataTable FindTable(string strSql)
        {
            return FindTable(strSql, null);
        }
        public async Task<DataTable> FindTableAsync(string strSql)
        {
            return await FindTableAsync(strSql, null);
        }

        public DataTable FindTable(string strSql, DbParameter[] dbParameter)
        {
            using (var dbConnection = db.Database.GetDbConnection())
            {
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter);
                return ConvertExtension.IDataReaderToDataTable(IDataReader);
            }
        }
        public async Task<DataTable> FindTableAsync(string strSql, DbParameter[] dbParameter)
        {
            return await Task.Run(() =>
            {
                using (var dbConnection = db.Database.GetDbConnection())
                {
                    var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter);
                    return ConvertExtension.IDataReaderToDataTable(IDataReader);
                }
            });
        }

        public DataTable FindTable(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            return FindTable(strSql, null, orderField, isAsc, pageSize, pageIndex, out total);
        }

        public DataTable FindTable(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            using (var dbConnection = db.Database.GetDbConnection())
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string OrderBy = "";

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC") + orderField.ToUpper().IndexOf("DESC") > 0)
                    {
                        OrderBy = "Order By " + orderField;
                    }
                    else
                    {
                        OrderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    OrderBy = "order by (select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + OrderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                total = Convert.ToInt32(new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, "Select Count(1) From (" + strSql + ") As t", dbParameter));
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, sb.ToString(), dbParameter);
                DataTable resultTable = ConvertExtension.IDataReaderToDataTable(IDataReader);
                resultTable.Columns.Remove("rowNum");
                return resultTable;
            }
        }

        public object FindObject(string strSql)
        {
            return FindObject(strSql, null);
        }
        public async Task<object> FindObjectAsync(string strSql)
        {
            return await FindObjectAsync(strSql, null);
        }

        public object FindObject(string strSql, DbParameter[] dbParameter)
        {
            using (var dbConnection = db.Database.GetDbConnection())
            {
                return new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, strSql, dbParameter);
            }
        }
        public async Task<object> FindObjectAsync(string strSql, DbParameter[] dbParameter)
        {
            return await Task.Run(() =>
           {
               using (var dbConnection = db.Database.GetDbConnection())
               {
                   return new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, strSql, dbParameter);
               }
           });
        }
        #endregion
    }
}
