using System;
using Application.Data.EF;


namespace Application.Data.Repository
{
    public class DbFactory
    {

        public static IDatabase Base()
        {

            //DbHelper.DbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), UnityIocHelper.GetmapToByName("DBcontainer", "IDbContext"));
            //return UnityIocHelper.DBInstance.GetService<IDatabase>(new ParameterOverride(
            // "connString", GetBaseDbKey()), new ParameterOverride(
            //  "DbType", ""));
            return new DataBase() ;
        }
    }
}
